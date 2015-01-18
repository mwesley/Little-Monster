using UnityEngine;
using System.Collections;

public class ClawAttack : MonoBehaviour {
	public float Speed;
	// Use this for initialization
	void Start () {
		StartCoroutine(rotate());
	}
	void FixedUpdate(){
				transform.Rotate (-Vector3.forward * Speed);
		}

	IEnumerator rotate (){
		yield return new WaitForSeconds(0.2f);
		Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Rope") {
			SpikeScript tempScript = (SpikeScript)coll.gameObject.GetComponentInParent(typeof(SpikeScript));
			tempScript.cutRope();
		}
	}
}