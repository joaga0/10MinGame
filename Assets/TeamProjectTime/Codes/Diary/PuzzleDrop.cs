using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleDrop : MonoBehaviour, IDropHandler
{
    public GameObject Puzzle_End;
    SpriteRenderer spriter_Puzzle;
    public Sprite New_Sprite;
    void Awake() 
    {
        spriter_Puzzle = Puzzle_End.GetComponent<SpriteRenderer>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            GameManager_Diary.instance.Puzzle_Game = true;
            spriter_Puzzle.sprite = New_Sprite;
        }
    }
}
