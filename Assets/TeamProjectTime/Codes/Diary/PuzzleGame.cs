using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleGame : MonoBehaviour , IBeginDragHandler, IDragHandler ,IEndDragHandler, IDropHandler
{
    RectTransform rectTransform;
    CanvasGroup canvasGroup;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
    public void OnDrop(PointerEventData eventData)
    {

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        //x 110.1761 y 69.82935
    }
}
