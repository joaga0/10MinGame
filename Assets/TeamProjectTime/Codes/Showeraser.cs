using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    // Start is called before the first frame update
    // 활성화할 캔버스를 지정합니다.
    public GameObject targetCanvas;
    public GameObject cabinet;

    // 버튼 클릭 시 호출되는 함수
    public void OnButtonClick()
    {
        // 캔버스를 활성화합니다.
        targetCanvas.SetActive(true);
        cabinet.SetActive(false);
    }
}