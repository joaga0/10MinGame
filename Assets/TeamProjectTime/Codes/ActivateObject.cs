using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    // 활성화할 오브젝트를 지정
    public GameObject targetObject;
  //  public GameObject outcanvas;
    // 버튼 클릭 시 호출되는 함수
    public void OnButtonClick()
    {
        // 오브젝트를 활성화
   //     outcanvas.SetActive(false);
        targetObject.SetActive(true);
        
    }
}
