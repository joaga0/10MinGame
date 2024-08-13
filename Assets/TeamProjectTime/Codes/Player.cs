using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;

    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    private void Awake() 
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() 
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    private void LateUpdate() 
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        if (inputVec.y > 0) 
        {
            anim.Play("Player_BehindMove");  // 위로 이동(뒤쪽으로)
        } else if (inputVec.y < 0) 
        {
            anim.Play("Player_FrontMove"); // 아래로 이동(앞쪽으로)
        } else if (inputVec.x > 0) 
        {
            spriter.flipX = inputVec.x < 0;
            anim.Play("Player_SideMove"); // 오른쪽 이동
        } else if (inputVec.x < 0) 
        {
            spriter.flipX = inputVec.x < 0;
            anim.Play("Player_SideMove");  // 왼쪽 이동
        }
    }
}
