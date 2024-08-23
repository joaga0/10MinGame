using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Connect : MonoBehaviour
{
    public RectTransform canvasRectTransform; // 캔버스의 RectTransform
    public Image lineImage; // 선을 그릴 UI 이미지 (이미지의 RectTransform을 사용하여 선을 그린다)
    public GameObject endingpanel;
    private RectTransform lineRectTransform; // 라인 이미지의 RectTransform
    private Vector2 startPoint; // 시작점
    private bool isDrawing = false; // 선을 그리고 있는지 여부
    public bool button1, button2;
    public GameObject cablePanel;

    void Start()
    {
        // 라인 이미지의 RectTransform을 가져옴
        lineRectTransform = lineImage.GetComponent<RectTransform>();
        button1 = false;
        button2 = false;
    }

    void Update()
    {
        // 마우스 위치 업데이트
        if (isDrawing)
        {
            Vector2 mousePosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, null, out mousePosition);
            
            Vector2 difference = mousePosition - startPoint;
            float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            lineRectTransform.sizeDelta = new Vector2(difference.magnitude, lineRectTransform.sizeDelta.y);
            lineRectTransform.anchoredPosition = startPoint + difference / 2;
            lineRectTransform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void StartDrawing()
    {
        // 현재 마우스 위치를 캔버스 로컬 좌표로 변환
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, null, out startPoint);

        isDrawing = true; // 선 그리기 시작
        lineImage.gameObject.SetActive(true); // 라인 이미지 활성화
        lineRectTransform.sizeDelta = new Vector2(0, lineRectTransform.sizeDelta.y); // 초기 길이 0으로 설정
        lineRectTransform.anchoredPosition = startPoint; // 시작점 설정
    }

    public void EndDrawing()
    {
        isDrawing = false; // 선 그리기 종료
        ClosePanel();
    }

    public void ClosePanel()
    {
        endingpanel.SetActive(true);
        if (button1 && button2){
            cablePanel.SetActive(false);
        }
    }
}
