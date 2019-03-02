using UnityEngine;
using System.Collections;

/// <summary>
/// Class parent untuk Script utama pada hampir semua minigame
/// </summary>

public class GameParent : MonoBehaviour
{
	public string backtoScene;

	[HideInInspector]
	public static string
		alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	public static int alphabetIndex = 1;

	/// Jika user menekan tombol back, game akan 
	/// kembali pada menu sebelumnya
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
			BackToScene ();
	}

	public virtual void BackToScene ()
	{
		Application.LoadLevel (backtoScene);
	}

	public virtual void OnPrevButtonClick ()
	{
		if (alphabetIndex == 1)
			alphabetIndex = 25;
		else
			alphabetIndex--;
		InitAlphabets ();
	}

	public virtual void OnNextButtonClick ()
	{
		if (alphabetIndex >= 25)
			alphabetIndex = 1;
		else
			alphabetIndex++;
		InitAlphabets ();
	}

	protected virtual void InitAlphabets ()
	{

	}

	protected char changeAlphabet ()
	{
		return alphabet [alphabetIndex];
	}
}
