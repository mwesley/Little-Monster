using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {
	public GameObject optionsScreen;
	public GameObject exitPrompt;
	
	void Start () {
		optionsScreen.SetActive (false);
		exitPrompt.SetActive (false);
	}

	public void Display(GameObject dis)
	{
		dis.SetActive (true);
	}
	public void Close(GameObject x)
	{
		x.SetActive (false);
	}
	public void StartGame()
	{
		Application.LoadLevel (1);
	}
	public void ExitGame()
	{
		Application.Quit ();
	}
}
