using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision coll)
	{
		Destroy (coll.gameObject);


	}
}
