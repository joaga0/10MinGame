using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BearRe : MonoBehaviour
{
    public bool canAct = false;
    public Text Player_T;
    public GameObject playerCanvas;
    public GameObject ActCanvas;
    public bool Displaying = false;

    void Update() 
    {
        if(canAct == false)
        {

        }
    }

    public void Action()
    {
        if(GameManager_Diary.instance.Needle && GameManager_Diary.instance.String) {
            canAct = true;
            ActCanvas.SetActive(true);
        }
        if(!canAct){
            Player_T.text = "도구를 찾아보자";
            if(Displaying == false) { //캐릭터 말풍선 뜨게하기
                StartCoroutine(DisplayCanvas());
            }
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
