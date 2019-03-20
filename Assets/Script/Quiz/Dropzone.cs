using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler
{
    public string partAnswer;

    QuizManager parent;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dragObj = eventData.pointerDrag;
        parent = GameObject.FindGameObjectWithTag("Quiz Manager").GetComponent<QuizManager>();

        if (dragObj.tag == "Letter" &&
            compareAnswer(dragObj.GetComponent<LetterTile>().alphabetLetter))
        {
            dragObj.GetComponent<LetterTile>().setParentPos(this.transform);
        }
        else
            parent.PlaySound(false);
    }

    private bool compareAnswer(string a)
    {
        return partAnswer == a;
    }
}