using UnityEngine;
using System.Collections;

public class TankBehaviour : MonoBehaviour {
	
	public GameObject missile;
	public float dist;
	public float atkSpeed;
	public Transform missileSpawn;
	public GameObject explosion;
	private GameObject target;
	private float timer;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player 1");
	}
	
	// Update is called once per frame
	void Update () {
		DistCheck ();
	}
	void DistCheck()
	{
		if (Vector3.Distance (transform.position, target.transform.position) < dist) 
		{
			timer += Time.deltaTime;
			if(timer > atkSpeed)
			{
				timer = 0;
				SpawnMissile();
			}
		}
	}
	void SpawnMissile()
	{
		Instantiate (missile, missileSpawn.position, Quaternion.identity);
	}
	void KillMe()
	{
		Destroy(this.gameObject);
		Instantiate (explosion, transform.position, Quaternion.identity);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject == target)
		{
			KillMe();
		}
		if(col.gameObject.tag == "Claw")
		{
			KillMe ();
		}
	}
}
