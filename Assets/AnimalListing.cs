using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Class yang meng-handle tambah aja Animals pada Learn to Read
/// </summary>

public class AnimalListing : GameParent
{
    public Image animalImage;
    public Button tapForSound, prevButton, nextButton;
    public AudioSource animalSource;
    public Text animalName;
    public List<Sprite> backgroundList = new List<Sprite>();
    public List<AnimalGroup> animalGroupList = new List<AnimalGroup>();

    Image background;
    AudioSource source;
    Animator anim;

    void Start()
    {
        background = GetComponent<Image>();
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        InitAnimalGroup();
        InitAlphabets();
    }

    /// Method yang berguna untuk mengganti object sesuai dengan Huruf awalan Animal yang ada
    /// Method ini dipanggil pada setiap user menekan tombol Prev atau Next
    protected override void InitAlphabets()
    {
        animalName.text = animalGroupList[alphabetIndex].objectName;
        animalImage.sprite = animalGroupList[alphabetIndex].objectImage;
        background.sprite = animalGroupList[alphabetIndex].background;
        source.PlayOneShot(animalGroupList[alphabetIndex].narator);
        anim.SetTrigger("AnimalFade");
    }

    /// Method yang digunakan untuk inisialisasi setiap object Animal
    private void InitAnimalGroup()
    {
        for (int i = 0; i < animalGroupList.Count; i++)
        {
//            animalGroupList[i].objectAlias = "Animal-" + animalGroupList[i].objectName[0];
//            animalGroupList[i].textColor = new Color(0, 0, 0, 255);
//            animalGroupList[i].narator = Resources.Load("Sounds/animal" + i) as AudioClip;
//            animalGroupList[i].animalSound = Resources.Load("Sounds/Animal Sounds/anml" + i) as AudioClip;

            //method untuk mengganti background pada binatang tertentu.
           
        }
    }

    public void playAnimalSound()
    {
        animalSource.PlayOneShot(animalGroupList[alphabetIndex].animalSound);
    }
}
