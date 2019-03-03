using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TheChoiseScript : GameParentQuiz {
    public Text objectName, alphabetText;
    public Image letterImage;
    public AudioClip openingWords, tryAgainWord, letterA;
	public List<AudioClip> congratWords = new List<AudioClip>();
	public List<CorrectWords> correctWordList = new List<CorrectWords>();
 	List<ObjectWord> objectList = new List<ObjectWord>();
    AudioSource source;
    Animator anim;

	    void Start()
    {
        
        foreach (CorrectWords correct in correctWordList)
            foreach (ObjectWord obj in correct.correctWords)
                objectList.Add(obj);
        
        source = GetComponent<AudioSource>();
        anim = transform.parent.GetComponent<Animator>();

        playSound(openingWords);
        Invoke("speakLetterA", openingWords.length+0.05f);
        InitAlphabets();
	}
		  public override void OnPrevButtonClick()
   		 {
            anim.SetTrigger("Next Quiz");
        base.OnPrevButtonClick();
            alphabetText.text = alphabet[alphabetIndex].ToString();
    	}

		public override void OnNextButtonClick()
   		 {
            anim.SetTrigger("Next Quiz");
        base.OnNextButtonClick();
            alphabetText.text = alphabet[alphabetIndex].ToString();
    	}

		  protected override void InitAlphabets()
    {
        CorrectWords correctTile = correctWordList[alphabetIndex];
        List<ObjectWord> problemTile = new List<ObjectWord>();

        // Jawaban yang benar awalnya disimpan pada tile pada index pertama
        problemTile.Add(correctTile.correctWords[Random.Range(0, correctTile.correctWords.Count)]);

        // Loop yang digunakan untuk merandom isi dari Tile lain sebagai pengecoh jawaban (jawaban yang salah).
        for (int i = 1; i < transform.childCount; i++)
        {
            problemTile.Add(objectList[Random.Range(0, objectList.Count)]);

            // Loop untuk mengecek, apakah objectWord yang telah dirandom sama dengan objectWord yang
            // disimpan pada Tile index sebelumnya
            for (int j = i - 1; j >= 0; j--)
            {
                // Jika object yang telah dirandom tidak sama dengan object yang disimpan pada
                // Tile index sebelumnya, Loop ini akan diskip
                if (problemTile[j].alphabet != problemTile[i].alphabet)
                    continue;
                // Jika sama, maka akan dirandom lagi agar tidak memiliki object yang sama
                else
                    problemTile[i] = objectList[Random.Range(0, objectList.Count)];
            }
        }

        // setelah di-generate, posisi dari setiap tile dirandom
        // agar jawaban yang benar tidak selalu pada index pertama.
        problemTile = Fisher_Yates_CardDeck_Shuffle(problemTile);

        //setelah dirandom, berikutnya memasukkan object yang telah digenerate ada Tile
        for (int i = 0; i < 3; i++)
            transform.GetChild(i).GetComponent<LetterTileBehaviour>().setObj(GetComponent<TheChoiseScript>(), problemTile[i]);
    }

    #region Random List
    //=======================================================================================//
    //==============================Fisher_Yates_CardDeck_Shuffle============================//
    //=======================================================================================//
    /// With the Fisher-Yates shuffle, first implemented on computers by Durstenfeld in 1964, 
    ///   we randomly sort elements. This is an accurate, effective shuffling method for all array types.
    public static List<ObjectWord> Fisher_Yates_CardDeck_Shuffle(List<ObjectWord> aList)
    {

        System.Random _random = new System.Random();

        ObjectWord myGO;

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

    public void playSound(AudioClip a)
    {
        source.PlayOneShot(a);
    }

    public void speakLetterA()
    {
        source.PlayOneShot(letterA);
    }

    public void playSound(bool isCorrect, AudioClip a)
    {
        if (isCorrect)
            source.PlayOneShot(a);
        else
            source.PlayOneShot(tryAgainWord);
    }

    public void AnimationTrigger(ObjectWord obj) {
        objectName.text = obj.objectName;
        alphabetText.text = obj.alphabet;
        letterImage.sprite = obj.objectImage;

        anim.SetTrigger("Fade in");
    }
    
}
