using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckTMPTransparency : MonoBehaviour
{
    public GameObject deskImage;  // TMP���� ���Ե� �θ� ������Ʈ
    public GameObject xButton;    // X ��ư ������Ʈ

    void Update()
    {
        // ��� �ڽ� TMP �ؽ�Ʈ�� �������� Ȯ��
        if (AreAllTMPsTransparent())
        {
            xButton.SetActive(true);  // X ��ư Ȱ��ȭ
        }
    }

    bool AreAllTMPsTransparent()
    {
        // deskImage ������Ʈ�� ��� �ڽ� �� TMP �ؽ�Ʈ�� ã��
        TextMeshProUGUI[] tmpTexts = deskImage.GetComponentsInChildren<TextMeshProUGUI>();

        foreach (TextMeshProUGUI tmp in tmpTexts)
        {
            if (tmp.color.a > 0)
            {
                return false;  // �ϳ��� �������� ������ false ��ȯ
            }
        }
        return true;  // ��� TMP �ؽ�Ʈ�� �����ϸ� true ��ȯ
    }
}
