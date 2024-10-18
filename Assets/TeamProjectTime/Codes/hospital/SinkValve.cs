using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkValve : MonoBehaviour
{
    public static bool valve = false;
    public static int valve_count = 0; //0~3
    public GameObject water;
    public Animator animator;
    private Vector3 dragStartPos;
    private bool isDragging = false;
    private Collider2D targetCollider;

    void Start()
    {
        targetCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        // 마우스 왼쪽 버튼을 누르면 드래그 시작
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            // 마우스가 콜라이더 위에서 눌렸는지 확인
            if (hit.collider != null && hit.collider == targetCollider)
            {
                dragStartPos = mousePos;
                isDragging = true;
            }
        }

        // 마우스 버튼을 떼면 드래그 끝
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            Vector3 dragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dragDirection = dragEndPos - dragStartPos;
            
            if (dragDirection.x < -1) // 왼쪽 드래그
            {
                // 드래그 끝 지점이 콜라이더 위인지 확인
                RaycastHit2D hit = Physics2D.Raycast(dragEndPos, Vector2.zero);
                if (hit.collider != null && hit.collider == targetCollider && valve_count > 0)
                {
                    animator.Play("LeftDrag");
                    valve_count--;
                }
                if(valve_count == 0)
                {
                    StartCoroutine(WaterAction(false));
                }
            }
            else if (dragDirection.x > 1) // 오른쪽 드래그
            {
                RaycastHit2D hit = Physics2D.Raycast(dragEndPos, Vector2.zero);
                if (hit.collider != null && hit.collider == targetCollider && valve_count < 3)
                {
                    animator.Play("RightDrag");
                    valve_count++;
                }
                if(valve_count == 3)
                {
                    StartCoroutine(WaterAction(true));
                }
            }
            isDragging = false;
        }
    }

    IEnumerator WaterAction(bool on_off)
    {
        yield return new WaitForSeconds(0.4f); 
        water.SetActive(on_off);
    }
}
