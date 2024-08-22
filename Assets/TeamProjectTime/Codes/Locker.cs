using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Locker : MonoBehaviour
{
    public Button[] buttons;  // 0~9 버튼 배열
    private List<int> correctSequence = new List<int> { 9, 7, 1, 2 };  // 올바른 버튼 순서
    private List<int> inputSequence = new List<int>();  // 플레이어가 누른 버튼 순서

    public GameObject door;  // 문 오브젝트

    private void Start()
    {
        // 각 버튼에 클릭 이벤트 할당
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;  // Capture the index for the closure
            buttons[i].onClick.AddListener(() => OnButtonPressed(index));
        }
    }

    void OnButtonPressed(int buttonValue)
    {
        // 플레이어가 누른 버튼 값을 입력 순서에 추가
        inputSequence.Add(buttonValue);

        // 입력된 버튼 순서가 올바른지 확인
        if (inputSequence.Count <= correctSequence.Count)
        {
            for (int i = 0; i < inputSequence.Count; i++)
            {
                if (inputSequence[i] != correctSequence[i])
                {
                    // 올바르지 않은 순서라면 입력 초기화
                    ResetInput();
                    return;
                }
            }

            // 모든 버튼이 올바른 순서로 눌렸을 경우
            if (inputSequence.Count == correctSequence.Count)
            {
                UnlockDoor();
            }
        }
        else
        {
            // 입력된 버튼이 너무 많다면 입력 초기화
            ResetInput();
        }
    }

    void ResetInput()
    {
        inputSequence.Clear();
        Debug.Log("잘못된 입력입니다. 다시 시도하세요.");
    }

    void UnlockDoor()
    {
        Debug.Log("문이 열렸습니다!");
        // 문을 여는 로직을 구현하세요 (예: 문 오브젝트 활성화/비활성화, 애니메이션 등)
        door.SetActive(false);
    }
}
