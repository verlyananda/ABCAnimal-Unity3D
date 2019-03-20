using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SquenceMasterControl : GameParent
{
    public Image background;
    public AudioClip introSound, wrongSound, CorrectSound;
    public Transform squenceParent, choiceParent;
    public CongratzUIButtonGroup UI;
    public List<Sprite> backgroundList = new List<Sprite>();

    int bgIndex = 0;
    string squenceProblem = "";
    string answer = "";
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        background.sprite = backgroundList[bgIndex];
        bgIndex++;

        source.PlayOneShot(introSound);
        InitAlphabets();
    }

    public override void OnNextButtonClick()
    {
        base.OnNextButtonClick();
        UI.OnActivatingUI(false);
        foreach (Transform t in squenceParent)
            t.GetComponent<ProblemBoxBehaviour>().hasFilled(false);
    }

    public override void OnPrevButtonClick()
    {
        base.OnPrevButtonClick();
        UI.OnActivatingUI(false);
        foreach (Transform t in squenceParent)
            t.GetComponent<ProblemBoxBehaviour>().hasFilled(false);
    }


    protected override void InitAlphabets()
    {
        int rnd = Random.Range(0, alphabet.Length - 7);
        for (int i = rnd, j = 0; i < rnd + 5; i++, j++)
        {
            squenceProblem += alphabet[i];
            squenceParent.transform.GetChild(j).GetChild(0).GetComponent<Text>().text = alphabet[i].ToString();
            squenceParent.transform.GetChild(j).GetComponent<ProblemBoxBehaviour>().hasFilled(true);
        }

        rnd = Random.Range(0, 5);
        squenceParent.transform.GetChild(rnd).GetComponent<ProblemBoxBehaviour>().hasFilled(false);

        setAnswerChoice(squenceParent.GetChild(rnd).GetChild(0).GetComponent<Text>().text);
        squenceParent.GetChild(rnd).GetChild(0).GetComponent<Text>().text = "";

    }

    private void setAnswerChoice(string a)
    {
        List<string> temp = new List<string>();
        List<Text> textList = new List<Text>();
        answer = a;

        foreach (Transform t in choiceParent)
        {
            textList.Add(t.GetChild(0).GetComponent<Text>());
            temp.Add(t.GetChild(0).GetComponent<Text>().text);
        }

        textList[0].text = a;
        temp[0] = a;
        for (int i = 1; i < choiceParent.childCount; i++)
        {
            textList[i].text = alphabet[Random.Range(0, alphabet.Length)].ToString();
            temp[i] = textList[i].text;

            for (int j = i - 1; j >= 0; j--)
            {
                if (textList[i].text != textList[i].text)
                    continue;
                else
                {
                    textList[i].text = alphabet[Random.Range(0, alphabet.Length)].ToString();
                    temp[i] = textList[i].text;
                }
            }
        }

        temp = Fisher_Yates_CardDeck_Shuffle(temp);
        for (int i = 0; i < temp.Count; i++)
            textList[i].text = temp[i];
    }

    public void setCorrectAnimation()
    {
        source.PlayOneShot(CorrectSound);
        UI.OnActivatingUI(true);
    }

    public void playWrongSound()
    {
        source.PlayOneShot(wrongSound);
    }

    public bool answerCheck(string a)
    {
        return a == answer;
    }

    #region Random List
    //=======================================================================================//
    //==============================Fisher_Yates_CardDeck_Shuffle============================//
    //=======================================================================================//
    /// With the Fisher-Yates shuffle, first implemented on computers by Durstenfeld in 1964, 
    ///   we randomly sort elements. This is an accurate, effective shuffling method for all array types.
    public static List<string> Fisher_Yates_CardDeck_Shuffle(List<string> aList)
    {

        System.Random _random = new System.Random();

        string myGO;

        int n = aList.Count;
        for (int i = 0; i < n; i++)
        {
            // NextDouble returns a random number between 0 and 1.
            // ... It is equivalent to Math.random() in Java.
            int r = i + (int)(_random.NextDouble() * (n - i));
            myGO = aList[r];
            aList[r] = aList[i];
            aList[i] = myGO;
        }

        return aList;
    }
    #endregion
}