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
    public GameObject Locker;
    public GameObject InsideCabinet;
    public GameObject Unlockers;
    public GameObject EraserCanvas;
    public GameObject deskwithdraw;
    public GameObject friend;
    public GameObject endingpanel;
    public GameObject inventory;

    public Texture2D eraserCursor;

    public float speed;
    private bool hasTalked = false; // 오늘 날짜가 표시되었는지 확인하는 플래그
    private bool hasTalked2 = false;
    private bool hasTalked3 = false;
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

        if (scanObject != null) {
            if (scanObject.CompareTag("today") && !hasTalked)
                {
                    talkText.text = "오늘이 몇월 며칠이지?";
                    GameManager.instance.Action(scanObject);
                    hasTalked = true; // 한번 실행된 후 다시 실행되지 않도록 설정
                }

            if (scanObject.CompareTag("insidecabinet") && !hasTalked2)
            {
                talkText.text = "아참, 사물함 내부를 안봤네!";
                GameManager.instance.Action(scanObject);
                hasTalked2 = true; // 한번 실행된 후 다시 실행되지 않도록 설정
            }

            if (scanObject.CompareTag("myfreind") && hasTalked3)
            {
                talkText.text = "헉 이게 다 뭐야.. 내 친구 정말 힘들었겠다..";
                GameManager.instance.Action(scanObject);
                hasTalked3 = true;
                // 한번 실행된 후 다시 실행되지 않도록 설정
            }

            if (scanObject.CompareTag("myfriend2"))
            {
                talkText.text = "이제 내가 도와줄게 혼자 힘들어 하지마!";
                GameManager.instance.Action(scanObject);
                // 한번 실행된 후 다시 실행되지 않도록 설정
                StartCoroutine(ending());
            }
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
                Locker.SetActive(true);
            }

            else if(scanObject.CompareTag("Unlockedcabinet"))
            {
                hasTalked = true;
                hasTalked2 = true;
                Unlockers.SetActive(false);
                InsideCabinet.SetActive(true);
                friend.SetActive(true);
                hasTalked3 = true;
            }

            else if (scanObject.CompareTag("drawingdesk"))
            {
                if (!EraserCanvas.activeSelf)
                {
                    talkText.text = "지우개가 없어서 지우지 못하네 ㅠㅠ";
                    GameManager.instance.Action(scanObject);
                }
                else
                {
                    deskwithdraw.SetActive(true);
                    Cursor.SetCursor(eraserCursor, Vector2.zero, CursorMode.Auto);
                }
            }
            else GameManager.instance.Action(scanObject);
        }
        if(!deskwithdraw.activeSelf)
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
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
    IEnumerator ending()
    {
        yield return new WaitForSeconds(2f);
        inventory.SetActive(false);
        endingpanel.SetActive(true);
    }
}