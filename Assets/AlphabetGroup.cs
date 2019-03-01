using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Class yang mendyimpan Nama, Huruf pertama, dan Suara pada
/// object di minigame Animal Ajaran .
/// </summary>
[System.Serializable]
public class AlphabetGroup
{
    public string objectName;
    public string objectAlias;
    public Color textColor;
    public Sprite objectImage;
    public AudioClip narator;

    public AlphabetGroup()
    {
        objectName = "";
        objectAlias = "";
        textColor = new Color();
        objectImage = null;
        narator = null;
    }
}