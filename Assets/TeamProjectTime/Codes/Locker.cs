using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Locker : MonoBehaviour
{
    public Button[] buttons;  // 0~9 ��ư �迭
    private List<int> correctSequence = new List<int> { 9, 7, 1, 2 };  // �ùٸ� ��ư ����
    private List<int> inputSequence = new List<int>();  // �÷��̾ ���� ��ư ����

    public GameObject OldCabinet;
    public GameObject OpenCabinet;
    public GameObject UnLocker;
    public GameObject UnLocker2;
    public GameObject whatobject;

    private void Start()
    {
        // �� ��ư�� Ŭ�� �̺�Ʈ �Ҵ�
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;  // Capture the index for the closure
            buttons[i].onClick.AddListener(() => OnButtonPressed(index));
        }
    }

    void OnButtonPressed(int buttonValue)
    {
        // �÷��̾ ���� ��ư ���� �Է� ������ �߰�
        inputSequence.Add(buttonValue);

        // �Էµ� ��ư ������ �ùٸ��� Ȯ��
        if (inputSequence.Count <= correctSequence.Count)
        {
            for (int i = 0; i < inputSequence.Count; i++)
            {
                if (inputSequence[i] != correctSequence[i])
                {
                    // �ùٸ��� ���� ������� �Է� �ʱ�ȭ
                    ResetInput();
                    return;
                }
            }

            // ��� ��ư�� �ùٸ� ������ ������ ���
            if (inputSequence.Count == correctSequence.Count)
            {
                UnlockDoor();
            }
        }
        else
        {
            // �Էµ� ��ư�� �ʹ� ���ٸ� �Է� �ʱ�ȭ
            ResetInput();
        }
    }

    void ResetInput()
    {
        inputSequence.Clear();
        Debug.Log("�߸��� �Է��Դϴ�. �ٽ� �õ��ϼ���.");
    }

    void UnlockDoor()
    {
        Debug.Log("���� ���Ƚ��ϴ�!");
        // ���� ���� ������ �����ϼ��� (��: �� ������Ʈ Ȱ��ȭ/��Ȱ��ȭ, �ִϸ��̼� ��)
        UnLocker.SetActive(false);
        UnLocker2.SetActive(true);
        OldCabinet.SetActive(false);
        OpenCabinet.SetActive(true);
        whatobject.SetActive(true);
    }
}
