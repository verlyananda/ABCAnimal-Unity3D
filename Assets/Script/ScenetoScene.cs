using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenetoScene : MonoBehaviour {

	// Use this for initialization
	public void QuizLetter(){
		Application.LoadLevel("QuizLetter");
	}

	public void QuizAnimal(){
		Application.LoadLevel("QuizAnimal");
	}

	public void AnimalABC(){
		Application.LoadLevel("Animal");
	}
}
