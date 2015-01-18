using UnityEngine;
using System.Collections;

public class CheckpointControl : MonoBehaviour {

	public int thisCheckpoint;
	public GameObject statObj;
	PlayerStats stats;
	private bool checkpointUsed;

	// Use this for initialization
	void Start () {
		stats = statObj.GetComponent<PlayerStats> ();
		checkpointUsed = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!checkpointUsed) 
		{
			if (other.gameObject.tag == "Player") 
			{
				stats.UpdateCheckpoint (thisCheckpoint, gameObject.transform.position);
				checkpointUsed = true;
			}
		}
	}
}
