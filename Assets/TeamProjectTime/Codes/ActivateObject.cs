using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    // Ȱ��ȭ�� ������Ʈ�� ����
    public GameObject targetObject;
  //  public GameObject outcanvas;
    // ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnButtonClick()
    {
        // ������Ʈ�� Ȱ��ȭ
   //     outcanvas.SetActive(false);
        targetObject.SetActive(true);
        
    }
}
