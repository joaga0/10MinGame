using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    // 커서로 사용할 스프라이트
    public Texture2D eraserCursor;

    void Start()
    {
        // 커서를 지우개 이미지로 변경
        Cursor.SetCursor(eraserCursor, Vector2.zero, CursorMode.Auto);
    }

    // 필요에 따라 커서를 기본 모양으로 되돌리는 함수
    public void ResetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
