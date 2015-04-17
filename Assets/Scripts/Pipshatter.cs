using UnityEngine;
using System.Collections;

public class Pipshatter : MonoBehaviour {
	public GameObject Pipe1;
	public GameObject Pipe2;
	public GameObject Pipe3;
	public GameObject Pipe4;
	public GameObject Pipe5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Pipe1.rigidbody.useGravity = true;
			Pipe2.rigidbody.useGravity = true;
			Pipe3.rigidbody.useGravity = true;
			Pipe4.rigidbody.useGravity = true;
			Pipe5.rigidbody.useGravity = true;

				}
	
	}
}
