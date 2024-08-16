using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator fadeAnimator;
    public string nextSceneName = "IntroScene";

    public void StartFadeOut()
    {
        fadeAnimator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}