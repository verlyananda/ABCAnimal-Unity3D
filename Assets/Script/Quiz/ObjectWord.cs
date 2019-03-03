using UnityEngine;
using System.Collections;

/// <summary>
/// Method yang digunakan untuk menyimpan value pada object tile yang digunakan pada
/// minigame Find the Answer
/// </summary>
[System.Serializable]
public class ObjectWord {
    public string objectName;
    public string alphabet;
    public Sprite objectImage;
    public AudioClip correctAnswer;

    public ObjectWord()
    {
        objectImage = null;
        alphabet = "";
        correctAnswer = null;
    }
}
