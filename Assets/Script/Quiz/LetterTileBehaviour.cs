using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Class yang meng-handle input dari user pada setiap tile yang digunakan sebagai
/// pilihan ganda pada minigame Find the Answer
/// </summary>

public class LetterTileBehaviour : MonoBehaviour
{
    public Image wrongImage;
    public string alphabet { private set; get; }

    Image child;
    ObjectWord obj = new ObjectWord();
    TheChoiseScript parent;

    /// method ini digunakan untuk meng-set value pada setiap tile mulai dari
    /// nama object, alphabet, gambar, sampai sound untuk jawaban benar
    public void setObj(TheChoiseScript parent, ObjectWord a)
    {
        obj = a;
        this.parent = parent;

        gameObject.name = obj.objectName + " button";
        alphabet = obj.alphabet;
        GetComponent<Image>().sprite = obj.objectImage;
    }

    /// method ini dipanggil setiap user menekan tile untuk menjawab
    public void onTileClicked()
    {
        bool isCorrect = false;
        
        if (alphabet == TheChoiseScript.alphabet[TheChoiseScript.alphabetIndex].ToString())
        {
            parent.AnimationTrigger(obj);
            isCorrect = true;
        }
        else
        {
            CreateWrongIcon();
            isCorrect = false;
        }

        parent.playSound(isCorrect, obj.correctAnswer);
    }

    /// method yang dipanggil ketika user menjawab dengan jawaban yang salah
    /// method ini berguna untuk gambar silang merah akan muncul dan memainkan sound try again
    private void CreateWrongIcon()
    {
        child = Instantiate(wrongImage, transform.position, transform.rotation) as Image;
        child.transform.SetParent(transform);
        Invoke("DestroyWrongIcon", 1.5f);
    }

    private void DestroyWrongIcon()
    {
        Destroy(child.gameObject);
    }
}