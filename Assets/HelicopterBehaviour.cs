using UnityEngine;
using System.Collections;

public class HelicopterBehaviour : MonoBehaviour {

	public float speed;
	public GameObject prop1;
	public GameObject prop2;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (transform.position.x, Random.Range (9, 13));
		speed = Random.Range (1.5f, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		MoveMe ();
	}
	void MoveMe()
	{
		rigidbody2D.velocity = new Vector2 (-speed, 0);
		prop1.transform.Rotate(new Vector3(0,speed*2,0));
		prop2.transform.Rotate(new Vector3(0,speed*2,0));
	}
	void KillMe()
	{
		Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy (this.gameObject);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			col.GetComponent<CityEnergy>().Heal(20f);
			KillMe();
		}
		if(col.gameObject.tag == "Tongue")
		{
			///latch on
		}
	}
}
