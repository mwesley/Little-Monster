using UnityEngine;
using System.Collections;

public class WallClimb : MonoBehaviour {

	PlayerMovement move;
	void Start()
	{
		move = GameObject.Find ("Player 1").GetComponent<PlayerMovement> ();
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
			move.canClimb = true;
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
			move.canClimb = false;
	}
}
