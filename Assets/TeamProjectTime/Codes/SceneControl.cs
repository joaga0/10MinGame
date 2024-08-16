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
                break;
            case 3:
                SceneManager.LoadScene("DiaryScene");
                Debug.Log("Game Scene Changed");
                break;
            default:
                Debug.Log("다른 아이템입니다.");
                break;
        }
        
    }
}
