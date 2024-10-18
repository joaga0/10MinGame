using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EraseUIText : MonoBehaviour
{
    public TextMeshProUGUI tmpText;  // TMP �ؽ�Ʈ ������Ʈ
    public float fadeSpeed = 0.5f;  // �ؽ�Ʈ�� ������� �ӵ�
    public AudioSource bgmAudioSource;  // BGM�� ����� AudioSource

    private bool isErasing = false;

    void Start()
    {
        // AudioSource�� ó������ ��Ȱ��ȭ
        bgmAudioSource.enabled = false;
        // loop�� ��Ȱ��ȭ, ó������ BGM�� �������� �ʵ��� ����
        bgmAudioSource.loop = false;
    }

    void Update()
    {
        // ���콺 Ŭ�� ���� ��
        if (Input.GetMouseButton(0))
        {
            // Raycast�� ����� TMP �ؽ�Ʈ�� �浹�� ����
            RectTransform rectTransform = tmpText.GetComponent<RectTransform>();
            Vector2 localMousePosition = rectTransform.InverseTransformPoint(Input.mousePosition);

            if (rectTransform.rect.Contains(localMousePosition))
            {
                if (!bgmAudioSource.isPlaying)
                {
                    // AudioSource Ȱ��ȭ �� BGM ��� ����
                    bgmAudioSource.enabled = true;
                    bgmAudioSource.Play();
                }

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
            // TMP �ؽ�Ʈ�� ���İ��� ����
            Color textColor = tmpText.color;
            textColor.a = Mathf.Clamp01(textColor.a - fadeSpeed * Time.deltaTime);
            tmpText.color = textColor;

            if (textColor.a == 0)
            {
                // �ؽ�Ʈ�� ������ �������� BGM�� ������ ��Ȱ��ȭ�Ͽ� ���� ������ ����ǵ��� ����
                bgmAudioSource.loop = false;
                // AudioSource�� ��Ȱ��ȭ�ϴ� ���, bgmAudioSource.enabled�� false�� �������� �ʰ� �ڿ������� ����ǵ��� �Ӵϴ�.
            }
        }
    }
}
