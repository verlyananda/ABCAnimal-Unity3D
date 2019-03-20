using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CongratzUIButtonGroup : MonoBehaviour {
    public Button backButton;

    CanvasGroup canvas;

    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        OnActivatingUI(false);
    }

    public void OnBackButtonClicked()
    {
        OnActivatingUI(false);
    }

    public void OnActivatingUI(bool a)
    {
        if (a)
            canvas.alpha = 1;
        else
            canvas.alpha = 0;

        canvas.interactable = a;
        canvas.blocksRaycasts = a;
    }
}
