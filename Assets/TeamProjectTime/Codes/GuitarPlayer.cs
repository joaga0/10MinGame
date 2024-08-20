using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarPlayer : MonoBehaviour
{
    public GameObject scanObject;
    Vector3 dirVec;
    Rigidbody2D rigid;

    private GuitarGameManager guitarManager;

    private void Awake() 
    {
        rigid = GetComponent<Rigidbody2D>();
        guitarManager = FindObjectOfType<GuitarGameManager>();
    }

    void Update()
    {
        //대화창
        if(Input.GetKeyDown(KeyCode.E) && scanObject != null)
        {
            if(scanObject.CompareTag("Guitar"))
            {
                guitarManager.Get_Guitar();
            }
            else if(scanObject.CompareTag("Amp"))
            {
                guitarManager.Open_Amp();
            }
            else GameManager.instance.Action(scanObject);
        }
    }

    void Turn_music()
    {
        StartCoroutine(guitarManager.left_music());
    }

    void FixedUpdate() 
    {
        //Ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("GetItem"));
        if(rayHit.collider != null) {
            Debug.Log("Rayhit");
            scanObject = rayHit.collider.gameObject;
        }
        else {
            scanObject = null;
        }
    }
}