using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerSample : MonoBehaviour
{
    public static GameManagerSample instance;
    public Text talkText;
    public GameObject playerCanvas;

    public GameObject ChangeScenePanel;

    Animator animator;

    public bool Displaying = false;

    public static int currentChapter = 2;
    void Awake()
    {
        instance = this;
        animator = ChangeScenePanel.GetComponent<Animator>();
    }

    //플레이어가 E 누르면 상호작용
    public void Action(GameObject scanObj)
    {
        if(scanObj != null){
            //씬 바꾸기
            if(currentChapter == scanObj.GetComponent<Items>().Id){
                switch (currentChapter)
                {
                    case 0:
                        talkText.text = "친구...\n이제야\n널 만나.";
                        break;
                    case 1:
                        talkText.text = "이 기타\n안 쳤더니\n낡았네.";
                        break;
                    case 2:
                        talkText.text = "우리 아들 일기네.\n어릴 때 더\n놀아줄걸...";
                        break;
                    case 3:
                        talkText.text = "당신이 없으니\n이 화초도\n슬퍼보여.";
                        break;
                    default:
                        Debug.Log("다른 아이템입니다.");
                        break;
                }
                if(Displaying == false) { //캐릭터 말풍선 뜨게하기
                    StartCoroutine(DisplayCanvas());
                }
                Invoke("FadeOut", 1f);
            }
            else{
                talkText.text = scanObj.name + "가\n놓여있다.";
                if(Displaying == false) { //캐릭터 말풍선 뜨게하기
                    StartCoroutine(DisplayCanvas());
                }
            }
        }
    }

    void FadeOut(){
        animator.SetTrigger("FadeOut");
        Invoke("ChangeScene", 4f);
    }

    void ChangeScene(){
        SceneControl.instance.GameScenesControl(currentChapter);
    }
    public void OpeningText()
    {
        Invoke("OpeningText1", 2f);
    }
    public void OpeningText1()
    {
        talkText.text = "정든 내 방...";
        if(Displaying == false) { //캐릭터 말풍선 뜨게하기
            StartCoroutine(DisplayCanvas());
        }
        Invoke("OpeningText2", 2.5f);
    }

    public void OpeningText2()
    {
        talkText.text = "추억이 담긴\n물건들이 많네.";
        if(Displaying == false) { //캐릭터 말풍선 뜨게하기
            StartCoroutine(DisplayCanvas());
        }
    }

    IEnumerator DisplayCanvas()
    {
        
        Displaying = true;
        playerCanvas.SetActive(true);   // 캔버스 활성화
        yield return new WaitForSeconds(2f);  // 2초 대기
        playerCanvas.SetActive(false);  // 캔버스 비활성화
        Displaying = false;
    }
}
