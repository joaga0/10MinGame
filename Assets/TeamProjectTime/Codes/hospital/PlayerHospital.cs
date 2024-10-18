using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHospital : MonoBehaviour
{
    public Vector2 inputVec;
    Vector3 dirVec;
    public GameObject scanObject;
    public GameObject sinkPanel;

    public float speed;

    public static bool panelOn = false;
    public static bool watered = false;

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
        if(panelOn == false){
            inputVec.x = Input.GetAxisRaw("Horizontal");
            inputVec.y = Input.GetAxisRaw("Vertical");
        }

        if(Input.GetKeyDown(KeyCode.E) && scanObject != null)
        {   
            if(scanObject.CompareTag("Sink")){
                if(ItemUI_Hospital.inventory[0] || ItemUI_Hospital.inventory[2]){
                    GameManager_Hospital.instance.openPanel(sinkPanel);
                    panelOn = true;
                }
                else{
                    GameManager_Hospital.instance.noticeSink(scanObject);
                }
            }
            if(scanObject.CompareTag("GetItem")){
                GameManager_Hospital.instance.getAction(scanObject);
                scanObject.GetComponent<GetItem_Hospital>().Get();
                scanObject.SetActive(false);
            }
            if(scanObject.CompareTag("Shelf")){
                if(ItemUI_Hospital.inventory[1]){
                    scanObject.GetComponent<GetItem_Hospital>().Put();
                    scanObject.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (!ItemUI_Hospital.inventory[1] && scanObject.transform.GetChild(0).gameObject.activeSelf == false){
                    GameManager_Hospital.instance.noticeShelf(scanObject);
                }
            }
            if(scanObject.CompareTag("Plant")){
                if(ItemUI_Hospital.inventory[2]){ //물주기
                    scanObject.GetComponent<GetItem_Hospital>().ChangeWateringpot();
                    GameManager_Hospital.instance.watering(scanObject);
                    watered = true;
                    ItemUI_Hospital.inventory[0]=true;
                    ItemUI_Hospital.inventory[2]=false;

                }
                else {
                    GameManager_Hospital.instance.noticeWater(scanObject);
                }
            }
            if(scanObject.CompareTag("Grandma")){
                GameManager_Hospital.instance.noticeGrandma(scanObject);
            }
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
            //Debug.Log("Rayhit");
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
