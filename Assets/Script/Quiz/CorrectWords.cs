using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Class untuk menyimpan beberapa object dari ObjectWord.
/// Digunakan untuk meng-sortir beberapa object yang memiliki awalan yang sama
/// </summary>

[System.Serializable]
public class CorrectWords {
    public string alphabet;
    public List<ObjectWord> correctWords = new List<ObjectWord>();

    public CorrectWords()
    {
        alphabet = "";
        correctWords = new List<ObjectWord>();
    }
}
