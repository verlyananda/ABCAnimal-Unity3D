using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class LetterBehaviour : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform prevParent;

    public void setParentTo(Transform parentDest)
    {
        prevParent = parentDest;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        prevParent = transform.parent;
        transform.SetParent(transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.SetParent(prevParent);
    }
}