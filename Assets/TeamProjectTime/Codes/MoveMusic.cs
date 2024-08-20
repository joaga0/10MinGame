using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMusic : MonoBehaviour
{
    public float moveSpeed; // 움직임 속도

    void Update()
    {
        // 오른쪽 위 방향으로 움직이기
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
