using UnityEngine;
using System.Collections;

public class DestroyBuilding : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider coll)
	{
		coll.rigidbody.useGravity = true;
		coll.gameObject.SendMessage("Shatter", coll.gameObject.transform.position);
	}
}
 