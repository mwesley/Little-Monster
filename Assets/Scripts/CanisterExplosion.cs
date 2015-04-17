using UnityEngine;
using System.Collections;

public class CanisterExplosion : MonoBehaviour {

	public GameObject player;
	public float freezetime;
	public bool freezing;
	public bool pillaralive = true;
	public float thrust;
	public GameObject iceexplosion;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
		if (freezing == true) {
			freezetime -= Time.deltaTime;
			
		}
		if (freezetime <= 0&&pillaralive == true) {
			Instantiate(iceexplosion,(new Vector3(-19.46f, 18.26f, 0.0f)), transform.rotation);
			player.GetComponent<PlayerMovement>().enabled = false;
			pillaralive = false;
			player.rigidbody2D.AddForce(new Vector3(2650.0f, 0.0f, 0.0f));
			freezetime = 5f;
		}
		if (Input.GetButtonUp ("Fire1")) {
			freezing = false;
			
		}
		
	}
	
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "BreathLeft") {
			freezing = true;
			
		}
		
	}

}