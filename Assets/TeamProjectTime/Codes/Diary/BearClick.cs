using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearClick : MonoBehaviour
{
    public GameObject[] String;

    public int ClickCount;
    public GameObject Now_Bear;
    public GameObject Bear_End;
    SpriteRenderer spriter_Bear;
    public Sprite New_Sprite;

    void Awake() 
    {
        spriter_Bear = Bear_End.GetComponent<SpriteRenderer>();
    }

    public void GoodBear()
    {
        if(ClickCount < 4)
        {
            String[ClickCount].SetActive(true);
            ClickCount++;
        }
        else if (ClickCount >= 4){
            String[ClickCount].SetActive(true);
            Now_Bear.SetActive(false);
            GameManager_Diary.instance.Bear_Game = true;
            spriter_Bear.sprite = New_Sprite;
        }
    }
}
