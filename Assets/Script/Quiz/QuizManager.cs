﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
public class QuizManager : GameParent
{
	public Image QuestionImage;
	public AudioClip introSound, wrongSound, CorrentSound;
	public Dropzone dropZoneAnswer;
	public LetterTile letter;
	public GameObject DropZonePanel, ShuffledLetterPanel;
	public CongratzUIButtonGroup congratzUI;
	public List<QuizAlphabet> quizList = new List<QuizAlphabet> ();

	AudioSource source;
	List<Dropzone> dropZoneList = new List<Dropzone> ();
	List<LetterTile> answerShuffleList = new List<LetterTile> ();

	public static InputState state;
//ADMOB INSTERSTITIAL
	
    bool hasShownAdOneTime;

    // Use this for initialization
  
    public void showInterstitialAd()
    {
        //Show Ad
        if (interstitial.IsLoaded())
        {
            interstitial.Show();

            //Stop Sound
            //

            Debug.Log("SHOW AD XXX");
        }

    }
     InterstitialAd interstitial;
    private void RequestInterstitialAds()
    {
        string adID = "ca-app-pub-1214654916114921/2518703007"; // Your ID Interstitital Admob

#if UNITY_ANDROID
        string adUnitId = adID;
#elif UNITY_IOS
        string adUnitId = adID;
#else
        string adUnitId = adID;
#endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);

        //***Test***
        AdRequest request = new AdRequest.Builder()
       .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
       .AddTestDevice("")  // My test device.
       .Build();

        //***Production***
        //AdRequest request = new AdRequest.Builder().Build();

        //Register Ad Close Event
        interstitial.OnAdClosed += Interstitial_OnAdClosed;

        // Load the interstitial with the request.
        interstitial.LoadAd(request);

        Debug.Log("Load Ads!");

    }

    //Ad Close Event
    private void Interstitial_OnAdClosed(object sender, System.EventArgs e)
    {
        //Resume Play Sound

    }

	//ADMOB BANNER INTERSTITIAL END







	void Start ()
	{
		 RequestInterstitialAds();
		source = GetComponent<AudioSource> ();
		source.PlayOneShot (introSound);
		InitAlphabets ();
	}

	public override void OnNextButtonClick ()
	{
		base.OnNextButtonClick ();
		congratzUI.OnActivatingUI (false);
	}

	public override void OnPrevButtonClick ()
	{
		base.OnPrevButtonClick ();
		congratzUI.OnActivatingUI (false);
	}

	protected override void InitAlphabets ()
	{
		QuizAlphabet currentQuiz = quizList [Random.Range (0, quizList.Count)];
		LetterTile temp;
		Dropzone dropzoneTemp;

		QuestionImage.sprite = currentQuiz.objectImage;
		foreach (char c in currentQuiz.name) {
			temp = Instantiate (letter) as LetterTile;
			temp.alphabetLetter = char.ToUpper (c).ToString ();
			temp.name = "Alphabet " + char.ToUpper (c).ToString ();

			dropzoneTemp = Instantiate (dropZoneAnswer) as Dropzone;
			dropzoneTemp.partAnswer = char.ToUpper (c).ToString ().ToString ();
			dropzoneTemp.transform.SetParent (DropZonePanel.transform);
			dropzoneTemp.transform.localScale = Vector3.one;
			dropzoneTemp.name = "Dropzone " + char.ToUpper (c).ToString ();

			dropZoneList.Add (dropzoneTemp);
			answerShuffleList.Add (temp);
		}

		answerShuffleList = FisherYatesCardDeckShuffle (answerShuffleList);
		foreach (LetterTile l in answerShuffleList) {
			l.transform.SetParent (ShuffledLetterPanel.transform);
			l.transform.localScale = Vector3.one;
		}
	}

    #region Random List
	//=======================================================================================//
	//==============================Fisher_Yates_CardDeck_Shuffle============================//
	//=======================================================================================//
	/// With the Fisher-Yates shuffle, first implemented on computers by Durstenfeld in 1964, 
	///   we randomly sort elements. This is an accurate, effective shuffling method for all array types.
	public static List<LetterTile> FisherYatesCardDeckShuffle (List<LetterTile> aList)
	{

		System.Random _random = new System.Random ();

		LetterTile myGO;

		int n = aList.Count;
		for (int i = 0; i < n; i++) {
			// NextDouble returns a random number between 0 and 1.
			// ... It is equivalent to Math.random() in Java.
			int r = i + (int)(_random.NextDouble () * (n - i));
			myGO = aList [r];
			aList [r] = aList [i];
			aList [i] = myGO;
		}

		return aList;
	}
    #endregion

	private void dropallChildren ()
	{
		answerShuffleList.Clear ();
		dropZoneList.Clear ();

		foreach (Transform t in ShuffledLetterPanel.transform)
			Destroy (t.gameObject);

		foreach (Transform t in DropZonePanel.transform)
			Destroy (t.gameObject);
	}

	public void PopupActive ()
	{
		if (ShuffledLetterPanel.transform.childCount == 0 && state == InputState.isFree) {
			PlaySound (true);
			congratzUI.OnActivatingUI (true);
			Invoke("showInterstitialAd", 3.0f); //Show Interstitial
			Debug.Log("Interstitial Shows !");
			dropallChildren ();
		}
	}

	public void PlaySound (bool a)
	{
		if (a)
			source.PlayOneShot (CorrentSound);
		else
			source.PlayOneShot (wrongSound);
	}
}

public enum InputState
{
	isHold,
	isFree
}