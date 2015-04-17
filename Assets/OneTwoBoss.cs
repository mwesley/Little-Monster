using UnityEngine;
using System.Collections;

public class OneTwoBoss : MonoBehaviour {

	public ValveScript ValveScript;
	public Collider2D ThisCollider;
	public Collider2D OtherCollider;

	private bool _gone;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (ValveScript.ValveHitBool) {
			Physics2D.IgnoreCollision (ThisCollider, OtherCollider, true);
			Destroy (this.gameObject, 2.0f);
		}


	
	}
}
