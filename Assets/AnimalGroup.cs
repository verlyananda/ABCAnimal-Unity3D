using UnityEngine;
using System.Collections;
[System.Serializable]
public class AnimalGroup : AlphabetGroup {
    public Sprite background;
    public AudioClip animalSound;

    public AnimalGroup()
    {
        objectName = "";
        objectAlias = "";
        textColor = new Color();
        objectImage = null;
        narator = null;
        animalSound = null;
    }
}
