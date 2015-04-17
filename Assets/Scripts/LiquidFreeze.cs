using UnityEngine;
using System.Collections;

public class LiquidFreeze : MonoBehaviour {
	public bool freezing;
	public GameObject iceblock;
	public float timeLeft = 5f;
	public Vector3 IcePosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (freezing == true) {
						timeLeft -= Time.deltaTime;
				}

		if(timeLeft <= 0)
		{
			Instantiate(iceblock,IcePosition,transform.rotation);
			timeLeft = 5;

				}
		if (Input.GetButtonUp ("Fire1")) {
			freezing = false;
			
		}
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "BreathLeft") {
			freezing = true;
		}
		if (other.name == "BreathRight") {
			freezing = true;
		}
	}
}
