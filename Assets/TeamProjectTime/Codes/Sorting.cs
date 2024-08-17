using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorting : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Y축의 위치에 따라 Sorting Order를 변경
        spriteRenderer.sortingOrder = -(int)(transform.position.y * 10);
    }
}
