using UnityEngine;
using System.Collections;

public class MissileBehaviour : MonoBehaviour {

	public float height;
	public float speed;
	public float killDistance;
	public float damage;
	public GameObject explosion;
	public GameObject fizzle;

	private CityEnergy ene;
	private GameObject target;
	private float theta;
	private Vector2 vec;
	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player 1");
		ene = target.GetComponent<CityEnergy> ();
		//transform.position = height;
		height = Random.Range (2f, 4f);
	}
	
	// Update is called once per frame
	void Update () {
		CheckDist ();
		MoveMe ();
	}
	void MoveMe()
	{
		if(transform.position.y < height)
		{
			rigidbody2D.velocity = new Vector2 (-speed, speed);
			vec = rigidbody2D.velocity.normalized;
			theta = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
		}
		else if(transform.position.y >= height)
		{
			rigidbody2D.velocity = new Vector2 (-speed, 0);
			vec = rigidbody2D.velocity.normalized;
			theta = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
		}
		transform.rotation = Quaternion.AngleAxis(-theta, Vector3.back);
	}
	void CheckDist()
	{
		if(Vector3.Distance(transform.position, target.transform.position) > killDistance)
		{
			KillMe (false);
		}
	}
	void KillMe(bool player)
	{
		if(player)
		{
			Instantiate (explosion, transform.position, Quaternion.identity);
		}
		else
		{
			Instantiate(fizzle, transform.position, Quaternion.identity);
		}
		Destroy (this.gameObject);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject == target)
		{
			ene.TakeHit(damage);
			KillMe(true);
		}
		if(col.gameObject.tag == "Breath")
		{
			KillMe(false);
		}
	}
}
