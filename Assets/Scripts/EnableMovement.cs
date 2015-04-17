using UnityEngine;
using System.Collections;

public class EnableMovement : MonoBehaviour {
	public GameObject player;
	public GameObject pipes;
	public BoxCollider2D[] boxcolliders;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player")
		{

			player.GetComponent<PlayerMovement>().enabled = true;
			boxcolliders = pipes.GetComponents<BoxCollider2D>();
			foreach (BoxCollider2D bc in boxcolliders) {
				bc.enabled = true;
			}

		}
}
}
