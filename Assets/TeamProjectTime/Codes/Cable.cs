using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cable : MonoBehaviour
{
    private GuitarGameManager cableManager;
    private Connect connectManager;
    public Connect lineConnector;
    public GameObject cablePanel;

    void Start()
    {
        cableManager = FindObjectOfType<GuitarGameManager>();
        connectManager = FindObjectOfType<Connect>();
    }

    public void cable_connect()
    {
        if (cableManager.havingGuitar && cableManager.ampOn)
        {
            //연결 가능
        }
    }

    public void OnButtonClick()
    {
        if (lineConnector != null)
        {
            if (gameObject.name == "Button1") // 첫 번째 버튼 클릭
            {
                if (!connectManager.button1 && !connectManager.button2)   //첫 클릭시
                {
                    lineConnector.StartDrawing(); // 선 그리기 시작
                }
                else if (!connectManager.button1)
                {
                    lineConnector.EndDrawing(); // 선 그리기 종료
                    cablePanel.gameObject.SetActive(false);
                }
                connectManager.button1 = true;
            }
            else if (gameObject.name == "Button2") // 두 번째 버튼 클릭
            {
                if (!connectManager.button1 && !connectManager.button2)   //첫 클릭시
                {
                    lineConnector.StartDrawing(); // 선 그리기 시작
                }
                else if (!connectManager.button2)
                {
                    lineConnector.EndDrawing(); // 선 그리기 종료
                    cablePanel.gameObject.SetActive(false);
                }
                connectManager.button2 = true;
            }
        }
    }
}
