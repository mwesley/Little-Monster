using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {

	Transform rope;
	
	// Use this for initialization
	void Start () {
		rope = transform.FindChild ("Rope");
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Claw") {
		  	cutRope();
		}
	}
	public void destroySpike() {
		Destroy (gameObject);
	}

	public void cutRope() {
		Destroy (rope.gameObject);
		rigidbody2D.isKinematic = false;
	}
}