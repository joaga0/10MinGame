using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Diary : MonoBehaviour
{
    public Vector2 inputVec;
    Vector3 dirVec;
    public GameObject scanObject;

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


        //대화창
        if(Input.GetKeyDown(KeyCode.E) && scanObject != null)
        {
            if(scanObject.CompareTag("GetItem")){
                scanObject.GetComponent<GetItem_Diary>().Get();
                GameManager_Diary.instance.Action(scanObject);
            }
            else if(scanObject.CompareTag("Bear")){
                scanObject.GetComponent<BearRe>().Action();
            }
            else if(scanObject.CompareTag("Puzzle")){
                scanObject.GetComponent<PuzzleRe>().Action();
            }
            else if(scanObject.CompareTag("NPC")){
                if(GameManager_Diary.instance.Puzzle_Game && GameManager_Diary.instance.Bear_Game){
                    scanObject.GetComponent<ChildClear>().DiaryClear();
                }
            }
            else    GameManager_Diary.instance.Action(scanObject);
            
        }
    }

    void FixedUpdate() 
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

        //Ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));
        if(rayHit.collider != null) {
            Debug.Log("Rayhit");
            scanObject = rayHit.collider.gameObject;
        }
        else {
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
        } else if (inputVec.y < 0) 
        {
            anim.Play("Player_FrontMove"); // 아래로 이동(앞쪽으로)
            dirVec = Vector3.down; //아래쪽
        } else if (inputVec.x > 0) 
        {
            spriter.flipX = inputVec.x < 0;
            anim.Play("Player_SideMove"); // 오른쪽 이동
            dirVec = Vector3.right; //오른쪽
        } else if (inputVec.x < 0) 
        {
            spriter.flipX = inputVec.x < 0;
            anim.Play("Player_SideMove");  // 왼쪽 이동
            dirVec = Vector3.left; //왼쪽
        }
    }
}
