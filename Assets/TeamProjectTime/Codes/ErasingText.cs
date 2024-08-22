using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UI 텍스트 사용 시 필요
using TMPro;  // TextMeshPro 사용 시 필요

public class ErasingText : MonoBehaviour
{
    public Text uiText;  // UI 텍스트를 사용하는 경우
    public TextMeshProUGUI tmpText;  // TextMeshPro를 사용하는 경우

    public float fadeSpeed = 0.01f;  // 텍스트가 사라지는 속도

    private bool isErasing = false;

    void Update()
    {
        // 마우스 클릭 및 드래그 중일 때
        if (Input.GetMouseButton(0))
        {
            // Raycast를 사용해 텍스트와 충돌을 감지
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isErasing = true;
                FadeText();
            }
        }
        else
        {
            isErasing = false;
        }
    }

    void FadeText()
    {
        if (isErasing)
        {
            // UI 텍스트의 알파값을 줄임
            if (uiText != null)
            {
                Color textColor = uiText.color;
                textColor.a = Mathf.Clamp01(textColor.a - fadeSpeed * Time.deltaTime);
                uiText.color = textColor;
            }

            // TextMeshPro 텍스트의 알파값을 줄임
            if (tmpText != null)
            {
                Color textColor = tmpText.color;
                textColor.a = Mathf.Clamp01(textColor.a - fadeSpeed * Time.deltaTime);
                tmpText.color = textColor;
            }
        }
    }
}