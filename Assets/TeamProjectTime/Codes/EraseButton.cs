using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseButton : MonoBehaviour
{
    // Start is called before the first frame update
    // Ȱ��ȭ�� ĵ������ �����մϴ�.
    public GameObject targetCanvas;

    // ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnButtonClick()
    {
        // ĵ������ Ȱ��ȭ�մϴ�.
        targetCanvas.SetActive(true);
    }
}