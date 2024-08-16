using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSequence : MonoBehaviour
{
    public Animator backgroundAnimator;
    public Animator logoAnimator;

    void Start()
    {
        // Background 애니메이션 시작
        backgroundAnimator.Play("BackgroundColor");
    }

    // Background 애니메이션에서 호출할 이벤트 함수
    public void OnBackgroundAnimationEnd()
    {
        // Background 애니메이션이 끝난 후 Logo 애니메이션 시작
        logoAnimator.Play("LogoFadeIn");
    }
}
