using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// script class behaviour untuk drag and drop tile
/// </summary>
public class LetterTile : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string alphabetLetter;
    Transform parentPos;
    QuizManager manager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Quiz Manager").GetComponent<QuizManager>();
        transform.GetChild(0).GetComponent<Text>().text = alphabetLetter;
    }

    public void setParentPos(Transform tr)
    {
        parentPos = tr;
        GetComponent<CanvasGroup>().interactable = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        parentPos = transform.parent;
        transform.SetParent(parentPos.parent);

        QuizManager.state = InputState.isHold;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.SetParent(parentPos);
        transform.position = parentPos.position;

        QuizManager.state = InputState.isFree;
        manager.PopupActive();
    }
}