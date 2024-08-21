using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notice : MonoBehaviour
{
    public GameObject August;
    public GameObject scanObject;
    Vector3 dirVec;
    Rigidbody2D rigid;

    void Update()
    {
        //대화창
        if (Input.GetKeyDown(KeyCode.E) && scanObject != null)
        {
            if (scanObject.CompareTag("Notice"))
            {
                August.SetActive(true);
            }

            else August.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        //Ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("GetItem"));
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
}