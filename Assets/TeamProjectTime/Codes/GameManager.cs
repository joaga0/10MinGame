using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text talkText;
    public GameObject playerCanvas;

    public bool Displaying = false;


    void Awake()
    {
        instance = this;
    }

    //플레이어가 E 누르면 상호작용
    public void Action(GameObject scanObj)
    {
        if(scanObj != null){
            talkText.text = "이것의 이름은 " + scanObj.name;
            if(Displaying == false) { //캐릭터 말풍선 뜨게하기
                StartCoroutine(DisplayCanvas());
            }
            //씬 바꾸기
            SceneControl.instance.GameScenesControl(scanObj.GetComponent<Items>().Id);
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
