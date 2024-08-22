using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextWriting : MonoBehaviour
{
    public TMP_Text textObj;
    string content;
    public Image image;
    public GameObject openingtext;
    // Start is called before the first frame update
    void Start()
    {
        content = "2019년 12월 30일\n아내가 입원한 병원";
        StartCoroutine(Typing(content));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Typing(string talk){
        textObj.text = null;
        for(int i=0; i<talk.Length; i++){
            textObj.text += talk[i];
            yield return new WaitForSeconds(0.08f);
        }
        yield return new WaitForSeconds(3f);
        openingtext.SetActive(false);
        StartCoroutine(FadeCoroutine());
    }
    IEnumerator FadeCoroutine(){
        float fadeCount = 1.0f;
        while(fadeCount > 0.0f){
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.02f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        gameObject.SetActive(false);
    }
}
