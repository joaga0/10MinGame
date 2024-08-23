using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChildClear : MonoBehaviour
{
    public Text talkText;
    public GameObject endingpanel;

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
