using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentPlayer : MonoBehaviour
{
    public GameObject August;
    public Vector2 inputVec;
    Vector3 dirVec;
    public GameObject scanObject;
    SpriteRenderer spriter;
    public GameObject OpenCabinet;
    public Text talkText;

    public float speed;
    private bool hasTalked = false; // 오늘 날짜가 표시되었는지 확인하는 플래그

    Rigidbody2D rigid;
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


        if (scanObject.CompareTag("today") && !hasTalked)
        {
            talkText.text = "오늘이 몇월 며칠이지?";
            GameManager.instance.Action(scanObject);
            hasTalked = true; // 한번 실행된 후 다시 실행되지 않도록 설정
        }

        //대화창
        if (Input.GetKeyDown(KeyCode.E) && scanObject != null)
        {
            if(scanObject.CompareTag("Notice"))
            {
                August.SetActive(true);
            }

            else if(scanObject.CompareTag("Cabinet"))
            {
                OpenCabinet.SetActive(true);
            }

            else GameManager.instance.Action(scanObject);
        }
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

        //Ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));
        if (rayHit.collider != null)
        {
            Debug.Log("Rayhit");
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        if (inputVec.y > 0)
        {
            anim.Play("Player_BehindMove");  // 위로 이동(뒤쪽으로)
            dirVec = Vector3.up; //위쪽
        }
        else if (inputVec.y < 0)
        {
            anim.Play("Player_FrontMove"); // 아래로 이동(앞쪽으로)
            dirVec = Vector3.down; //아래쪽
        }
        else if (inputVec.x > 0)
        {
            spriter.flipX = inputVec.x < 0;
            anim.Play("Player_SideMove"); // 오른쪽 이동
            dirVec = Vector3.right; //오른쪽
        }
        else if (inputVec.x < 0)
        {
            spriter.flipX = inputVec.x < 0;
            anim.Play("Player_SideMove");  // 왼쪽 이동
            dirVec = Vector3.left; //왼쪽
        }
    }
}