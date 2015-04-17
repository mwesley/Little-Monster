using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDControl : MonoBehaviour {
	public GameObject prompt;
	public GameObject pause;
	public GameObject options;
	public GameObject exit;
	public Image fade;
	public bool isDebug;
	public GameObject debugButton;
	public Text debugText;
	public GameObject warpButton;
	public GameObject warpScreen;
	public Text helpText;
	public string[] helpTextArray;
	private bool isPrompt;
	public Text objectiveText;
	public string[] objectiveArray;
	public int curObjective;
	private float timer;

	// Use this for initialization
	void Start () {
		prompt.SetActive (false);
		options.SetActive (false);
		exit.SetActive (false);
		pause.SetActive (false);
		warpScreen.SetActive (false);
		warpButton.SetActive (false);
		helpText.text = helpTextArray [Application.loadedLevel-1];
		debugText.color = Color.red;
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		CheckHelp ();
		CheckPause ();
		UpdateObjective ();
	}
	private void CheckHelp()
	{
		if(Input.GetKey(KeyCode.H))
		{
			if(!isPrompt)
			{
				isPrompt = true;
				Display(prompt);
			}
		}
		
		if(isPrompt)
		{
			timer+= Time.deltaTime;
			if(timer > 0.5f)
			{
				fade.CrossFadeAlpha(0f, 1f, false);
			}
			if(timer > 2.5f)
			{
				Close (prompt);
				isPrompt = false;
				timer = 0;
			}
		}
	}
	private void CheckPause()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(pause.activeSelf)
			{
				options.SetActive (false);
				exit.SetActive (false);
				pause.SetActive (false);
				warpScreen.SetActive (false);
				Time.timeScale = 1;
			}
			else
			{
				Time.timeScale = 0;
				pause.SetActive(true);
			}
		}
	}
	private void UpdateObjective()
	{
		objectiveText.text = objectiveArray [curObjective];
	}
	public void ToggleDebug()
	{
		if(isDebug)
		{
			isDebug = false;
			debugText.text = "Debug - False";
			debugText.color = Color.red;
			warpButton.SetActive(false);
		}
		else
		{
			isDebug = true;
			debugText.text = "Debug - True";
			debugText.color = Color.green;
			warpButton.SetActive(true);
		}
	}
	public void WarpLevel(int level)
	{
		Application.LoadLevel (level);
	}
	public void Display(GameObject dis)
	{
		dis.SetActive (true);
	}
	public void Close(GameObject x)
	{
		x.SetActive (false);
	}
}
