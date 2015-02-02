using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {

	Transform rope;
	GameObject cam;
	SpikeControl controlScript;
	bool falling;
	
	// Use this for initialization
	void Start () {
		rope = transform.FindChild ("Rope");
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		controlScript = (SpikeControl)cam.GetComponent (typeof(SpikeControl));
		falling = false;
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.E)) {
			cutRope();
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Claw") {
			cutRope ();
		} else if (falling) {
			destroySpike();
		}
	}
	public void destroySpike() {
		controlScript.removeSpike ();
		Destroy (gameObject);
	}

	public void cutRope() {
		Destroy (rope.gameObject);
		falling = true;
		rigidbody2D.isKinematic = false;
	}
}