using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChildClear : MonoBehaviour
{
    public Text talkText;
    public GameObject endingpanel;
    public Sprite Happy;
    SpriteRenderer spriter;
    private void Awake() {
        spriter = GetComponent<SpriteRenderer>();
    }
    private void Update() {
        if(GameManager_Diary.instance.Bear_Game && GameManager_Diary.instance.Puzzle_Game){
            spriter.sprite = Happy;
        }
    }
    // Update is called once per frame
    public void DiaryClear()
    {
        StartCoroutine(DiaryTalk());
    }

    IEnumerator DiaryTalk()
    {
        talkText.text = "아빠 사랑해요 !";
        yield return new WaitForSeconds(3f);
        talkText.text = "아빠 최고!";
        yield return new WaitForSeconds(3f);
        endingpanel.SetActive(true);
    }
}
