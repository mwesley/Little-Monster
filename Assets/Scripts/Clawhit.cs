using UnityEngine;
using System.Collections;

public class Clawhit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Claw") {
			SpikeScript tempScript = (SpikeScript)coll.gameObject.GetComponentInParent(typeof(SpikeScript));
			tempScript.cutRope();
		}
	}
}