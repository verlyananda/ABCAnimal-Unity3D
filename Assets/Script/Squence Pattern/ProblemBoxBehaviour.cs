using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ProblemBoxBehaviour : MonoBehaviour, IDropHandler
{
    Text childText;
    bool isFilled = false;
    SquenceMasterControl parentScript;

    void Start()
    {
        if (transform.GetChild(0).GetComponent<Text>() != null)
            childText = transform.GetChild(0).GetComponent<Text>();

        parentScript = transform.parent.parent.GetComponent<SquenceMasterControl>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!isFilled && parentScript.answerCheck(eventData.pointerDrag.transform.GetChild(0).GetComponent<Text>().text))
        {
            //eventData.pointerDrag.GetComponent<LetterBehaviour>().setParentTo(this.transform);
            childText.text = eventData.pointerDrag.transform.GetChild(0).GetComponent<Text>().text;
            parentScript.setCorrectAnimation();
        }
        else
            parentScript.playWrongSound();
    }

    public void hasFilled(bool a)
    {
        isFilled = a;
    }
}