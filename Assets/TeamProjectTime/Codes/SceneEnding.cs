using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class SceneEnding : MonoBehaviour
{
    public TMP_Text textObj;
    string content;
    public Image image;
    public GameObject endingtext;
    public int sceneId;
    // Start is called before the first frame update
    void Awake()
    {
        switch(sceneId){
            case 0:
                content = "그때, 내가 너에게 더 관심을 가져줬다면\n우리 같이 늙어갈 수 있었을 텐데...\n나 지금까지 널 잊은 적이 없어.";
                break;
            case 1:
                content = "그날 봤던 버스킹은 내 가슴을 뛰게 했었지.\n한 때, 나도 음악을 하는 꿈을 꾸었는데...\n조금만 더 그 꿈을 쫓아볼 걸 그랬어.";
                break;
            case 2:
                content = "그땐 네가 이렇게 빨리 커버릴 줄 몰랐어.\n일이 바쁘다는 이유로 너무 소홀했지.\n어렸을 때, 많은 추억을 만들어 줬어야 했는데...\n아들아 아빠가 미안해.";
                break;
            case 3:
                content = "당신이 힘없는 소리할 때,\n더 마음이 아파서 듣기 싫다고만 했었지.\n그때라도 당신의 미소를 봤어야 했는데...\n많이 보고싶어.";
                break;
        }
        StartCoroutine(FadeCoroutine());
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
        SceneControl.instance.GameScenesControl(9);
    }
    IEnumerator FadeCoroutine(){
        float fadeCount = 0f;
        while(fadeCount < 1.0f){
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.02f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        StartCoroutine(Typing(content));
    }
}
