using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem_Diary : MonoBehaviour
{
    public ItemUI ItemUIScript;
    public int Getid;

    public void Get()
    {
        ItemUIScript.ActiveItemUI(Getid);
        switch(Getid){
            case 0:
                GameManager_Diary.instance.talkText.text = "바늘을 찾았다";
                GameManager_Diary.instance.Needle = true;
                break;
            case 1:
                GameManager_Diary.instance.talkText.text = "실을 찾았다";
                GameManager_Diary.instance.String = true;
                break;
            case 2:
                GameManager_Diary.instance.talkText.text = "퍼즐을 찾았다";
                GameManager_Diary.instance.Puzzle = true;
                break;
        }
    }
}
