using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {
    public int currentLevel;

	// Use this for initialization
	void Awake () {
        currentLevel = Application.loadedLevel;
	}
	
	// Update is called once per frame
	void Update () {

	}
    void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetButtonDown("Interact"))
        {
            Application.LoadLevel(currentLevel+1);
        }
    }
}
