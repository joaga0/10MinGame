using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public static SceneControl instance;

    void Awake() 
    {
        instance = this;
    }
    
    public void GameScenesControl(int Id)
    {
        switch (Id)
        {
            case 0:
                SceneManager.LoadScene("ClassroomScene");
                Debug.Log("Game Scene Changed : ClassroomScene");
                GameManagerSample.currentChapter++;
                break;
            case 1:
                SceneManager.LoadScene("GuitarScene");
                Debug.Log("Game Scene Changed : GuitarScene");
                GameManagerSample.currentChapter++;
                break;
            case 2:
                SceneManager.LoadScene("DiaryScene");
                Debug.Log("Game Scene Changed : DiaryScene");
                GameManagerSample.currentChapter++;
                break;
            case 3:
                SceneManager.LoadScene("HospitalScene");
                Debug.Log("Game Scene Changed : HospitalScene");
                GameManagerSample.currentChapter++;
                break;
            case 5:
                SceneManager.LoadScene("IntroScene");
                Debug.Log("Game Scene Changed : IntroScene");
                break;
            case 9:
                SceneManager.LoadScene("SampleScene");
                Debug.Log("Game Scene Changed : SamepleScene");
                break;
            case 10:
                SceneManager.LoadScene("EndingScene");
                Debug.Log("Game Scene Changed : EndingScene");
                break;
            default:
                Debug.Log("다른 아이템입니다.");
                break;
        }
        
    }
}
