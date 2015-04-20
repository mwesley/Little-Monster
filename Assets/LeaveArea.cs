using UnityEngine;
using System.Collections;

public class LeaveArea : MonoBehaviour {
	private bool canLeave;
	public GameObject prompt;

	void Start()
	{
		prompt.SetActive (false);
	}

	void Update () 
	{
		if(canLeave)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				Application.LoadLevel(Application.loadedLevel+1);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		canLeave = true;
		prompt.SetActive (true);
	}
	void OnTriggerExit2D(Collider2D col)
	{
		canLeave = false;
		prompt.SetActive (false);
	}
}
