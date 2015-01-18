using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {


	private int currentCheckpoint;
	private Vector2 respawnLocation;

	public GameObject player;
	PlayerMovement playerMove;

	// Use this for initialization
	void Start () {
		playerMove = player.GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void UpdateCheckpoint(int checkpoint, Vector2 loc)
	{
		currentCheckpoint = checkpoint;
		respawnLocation = loc;
	}
	public void killPlayer()
	{
		player.transform.position = respawnLocation;
		playerMove.canMove = false;
	}
}