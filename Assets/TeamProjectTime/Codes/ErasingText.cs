using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UI �ؽ�Ʈ ��� �� �ʿ�
using TMPro;  // TextMeshPro ��� �� �ʿ�

public class ErasingText : MonoBehaviour
{
    public Text uiText;  // UI �ؽ�Ʈ�� ����ϴ� ���
    public TextMeshProUGUI tmpText;  // TextMeshPro�� ����ϴ� ���

    public float fadeSpeed = 0.01f;  // �ؽ�Ʈ�� ������� �ӵ�

    private bool isErasing = false;

    void Update()
    {
        // ���콺 Ŭ�� �� �巡�� ���� ��
        if (Input.GetMouseButton(0))
        {
            // Raycast�� ����� �ؽ�Ʈ�� �浹�� ����
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
            // UI �ؽ�Ʈ�� ���İ��� ����
            if (uiText != null)
            {
                Color textColor = uiText.color;
                textColor.a = Mathf.Clamp01(textColor.a - fadeSpeed * Time.deltaTime);
                uiText.color = textColor;
            }

            // TextMeshPro �ؽ�Ʈ�� ���İ��� ����
            if (tmpText != null)
            {
                Color textColor = tmpText.color;
                textColor.a = Mathf.Clamp01(textColor.a - fadeSpeed * Time.deltaTime);
                tmpText.color = textColor;
            }
        }
    }
}