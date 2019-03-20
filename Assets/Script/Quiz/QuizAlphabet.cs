using UnityEngine;
using System.Collections;

[System.Serializable]
public class QuizAlphabet {
    public string name;
    public int wordCount;
    public Sprite objectImage;
    public AudioClip naratorSound;

    public QuizAlphabet()
    {
        name = "";
        wordCount = -1;
        objectImage = new Sprite();
        naratorSound = new AudioClip();
    }
}
