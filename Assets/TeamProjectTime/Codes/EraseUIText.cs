using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EraseUIText : MonoBehaviour
{
    public TextMeshProUGUI tmpText;  // TMP 텍스트 컴포넌트
    public float fadeSpeed = 0.5f;  // 텍스트가 사라지는 속도
    public AudioSource bgmAudioSource;  // BGM을 재생할 AudioSource

    private bool isErasing = false;

    void Start()
    {
        // AudioSource를 처음에는 비활성화
        bgmAudioSource.enabled = false;
        // loop를 비활성화, 처음부터 BGM이 루프하지 않도록 설정
        bgmAudioSource.loop = false;
    }

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
                if (!bgmAudioSource.isPlaying)
                {
                    // AudioSource 활성화 및 BGM 재생 시작
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
            // TMP 텍스트의 알파값을 줄임
            Color textColor = tmpText.color;
            textColor.a = Mathf.Clamp01(textColor.a - fadeSpeed * Time.deltaTime);
            tmpText.color = textColor;

            if (textColor.a == 0)
            {
                // 텍스트가 완전히 지워지면 BGM의 루프를 비활성화하여 끝날 때까지 재생되도록 설정
                bgmAudioSource.loop = false;
                // AudioSource를 비활성화하는 대신, bgmAudioSource.enabled를 false로 설정하지 않고 자연스럽게 종료되도록 둡니다.
            }
        }
    }
}
