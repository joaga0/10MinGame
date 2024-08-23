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

    public Texture2D eraserCursor;

    public float speed;
    private bool hasTalked = false; // ���� ��¥�� ǥ�õǾ����� Ȯ���ϴ� �÷���
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
                    talkText.text = "������ ��� ��ĥ����?";
                    GameManager.instance.Action(scanObject);
                    hasTalked = true; // �ѹ� ����� �� �ٽ� ������� �ʵ��� ����
                }

            if (scanObject.CompareTag("insidecabinet") && !hasTalked2)
            {
                talkText.text = "����, �繰�� ���θ� �Ⱥó�!";
                GameManager.instance.Action(scanObject);
                hasTalked2 = true; // �ѹ� ����� �� �ٽ� ������� �ʵ��� ����
            }

            if (scanObject.CompareTag("myfreind") && hasTalked3)
            {
                talkText.text = "�� �̰� �� ����.. �� ģ�� ���� ������ڴ�..";
                GameManager.instance.Action(scanObject);
                hasTalked3 = true;
                // �ѹ� ����� �� �ٽ� ������� �ʵ��� ����
            }

            if (scanObject.CompareTag("myfriend2"))
            {
                talkText.text = "���� ���� �����ٰ� ȥ�� ����� ������!"; //맨마지막 대사
                GameManager.instance.Action(scanObject);
                // �ѹ� ����� �� �ٽ� ������� �ʵ��� ����
                StartCoroutine(ChangeScene());
            }
        }

        //��ȭâ
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
                    talkText.text = "���찳�� ��� ������ ���ϳ� �Ф�";
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
            anim.Play("Player_BehindMove");  // ���� �̵�(��������)
            dirVec = Vector3.up; //����
        }
        else if (inputVec.y < 0)
        {
            anim.Play("Player_FrontMove"); // �Ʒ��� �̵�(��������)
            dirVec = Vector3.down; //�Ʒ���
        }
        else if (inputVec.x > 0)
        {
            spriter.flipX = inputVec.x < 0;
            anim.Play("Player_SideMove"); // ������ �̵�
            dirVec = Vector3.right; //������
        }
        else if (inputVec.x < 0)
        {
            spriter.flipX = inputVec.x < 0;
            anim.Play("Player_SideMove");  // ���� �̵�
            dirVec = Vector3.left; //����
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        endingpanel.SetActive(true);
    }
}