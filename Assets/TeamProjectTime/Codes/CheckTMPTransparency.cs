using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckTMPTransparency : MonoBehaviour
{
    public GameObject deskImage;  // TMP들이 포함된 부모 오브젝트
    public GameObject xButton;    // X 버튼 오브젝트

    void Update()
    {
        // 모든 자식 TMP 텍스트가 투명한지 확인
        if (AreAllTMPsTransparent())
        {
            xButton.SetActive(true);  // X 버튼 활성화
        }
    }

    bool AreAllTMPsTransparent()
    {
        // deskImage 오브젝트의 모든 자식 중 TMP 텍스트를 찾음
        TextMeshProUGUI[] tmpTexts = deskImage.GetComponentsInChildren<TextMeshProUGUI>();

        foreach (TextMeshProUGUI tmp in tmpTexts)
        {
            if (tmp.color.a > 0)
            {
                return false;  // 하나라도 투명하지 않으면 false 반환
            }
        }
        return true;  // 모든 TMP 텍스트가 투명하면 true 반환
    }
}
