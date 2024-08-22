using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public GameObject timeline;

    void Start()
    {
    }

    void Update()
    {
        // 마우스 좌클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            // FadeOut 트리거를 설정하여 애니메이션 실행
            timeline.SetActive(true);
            Invoke("StartPlay", 6.0f);
        }
    }
    void StartPlay(){
        SceneManager.LoadScene("SampleScene");
    }
}
