using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro를 사용하기 위해 필요

public class EraseUIText : MonoBehaviour
{
    public TextMeshProUGUI tmpText;  // TMP 텍스트 컴포넌트
    public float fadeSpeed = 0.5f;  // 텍스트가 사라지는 속도

    private bool isErasing = false;

    void Update()
    {
        // 마우스 클릭 중일 때
        if (Input.GetMouseButton(0))
        {
            // Raycast를 사용해 TMP 텍스트와 충돌을 감지
            RectTransform rectTransform = tmpText.GetComponent<RectTransform>();
            Vector2 localMousePosition = rectTransform.InverseTransformPoint(Input.mousePosition);

            if (rectTransform.rect.Contains(localMousePosition))
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
            // TMP 텍스트의 알파값을 줄임
            Color textColor = tmpText.color;
            textColor.a = Mathf.Clamp01(textColor.a - fadeSpeed * Time.deltaTime);
            tmpText.color = textColor;
        }
    }
}

