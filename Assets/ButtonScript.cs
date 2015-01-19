using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	bool isActive;	//Whether or not the button can be pressed


	// Use this for initialization
	void Start () {
		isActive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			renderer.material.color = Color.green;
		} else {
			renderer.material.color = Color.red;
		}
	}

	void press() {
		isActive = false;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			if(isActive) {
				press();
			}
		}
	}
}