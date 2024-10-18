using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    // Ŀ���� ����� ��������Ʈ
    public Texture2D eraserCursor;

    void Start()
    {
        // Ŀ���� ���찳 �̹����� ����
        Cursor.SetCursor(eraserCursor, Vector2.zero, CursorMode.Auto);
    }

    // �ʿ信 ���� Ŀ���� �⺻ ������� �ǵ����� �Լ�
    public void ResetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
