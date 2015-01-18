using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	public GameObject statsObj;
	PlayerStats stats;

	// Use this for initialization
	void Start () {
		stats = statsObj.GetComponent<PlayerStats> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			stats.killPlayer();
		}
	}

}
