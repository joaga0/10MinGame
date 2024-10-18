using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Hospital : MonoBehaviour
{
    public static GameManager_Hospital instance;
    public Text talkText;
    public GameObject playerCanvas;

    public bool Displaying = false;


    void Awake()
    {
        instance = this;
    }

    //플레이어가 E 누르면 상호작용
    public void getAction(GameObject scanObj)
    {
        if(scanObj != null){
            talkText.text = scanObj.name+"를 획득했다 !";
            if(Displaying == false) { //캐릭터 말풍선 뜨게하기
                StartCoroutine(DisplayCanvas());
            }
        }
    }
    public void noticeSink(GameObject scanObj)
    {
        if(scanObj != null){
            talkText.text = "세면대가 있다";
            if(Displaying == false) { //캐릭터 말풍선 뜨게하기
                StartCoroutine(DisplayCanvas());
            }
        }
    }
    public void noticeShelf(GameObject scanObj)
    {
        if(scanObj != null){
            talkText.text = "햇빛이 잘 드는 곳이다";
            if(Displaying == false) { //캐릭터 말풍선 뜨게하기
                StartCoroutine(DisplayCanvas());
            }
        }
    }
    public void noticeWater(GameObject scanObj)
    {
        if(scanObj != null){
            talkText.text = "물이 필요해 보인다";
            if(Displaying == false) { //캐릭터 말풍선 뜨게하기
                StartCoroutine(DisplayCanvas());
            }
        }
    }
    public void watering(GameObject scanObj)
    {
        if(scanObj != null){
            talkText.text = "화초에 물을 주었다 !";
            if(Displaying == false) { //캐릭터 말풍선 뜨게하기
                StartCoroutine(DisplayCanvas());
            }
        }
    }

    public void noticeGrandma(GameObject scanObj)
    {
        if(scanObj != null){
            talkText.text = "당신... 보고싶었어    많이";
            if(Displaying == false) { //캐릭터 말풍선 뜨게하기
                StartCoroutine(DisplayCanvas());
            }
        }
    }

    IEnumerator DisplayCanvas()
    {
        Displaying = true;
        playerCanvas.SetActive(true);   // 캔버스 활성화
        yield return new WaitForSeconds(1.5f);  // 2초 대기
        playerCanvas.SetActive(false);  // 캔버스 비활성화
        Displaying = false;
    }

    public void openPanel(GameObject sinkPanel)
    {
        sinkPanel.SetActive(true);
    }
}
