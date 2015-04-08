using UnityEngine;
using System.Collections;

public class EnemyMoveAI : MonoBehaviour {

	GameObject target;
	float speed, viewDist, move, stayDist, dist;
	bool headButt;
	public Transform headCheck;
	public LayerMask whatIsPlayer;
	float radius = 0.2f;
	public bool frozen;
	public GameObject ice;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player");

		speed = 3.0f;
		viewDist = 3.0f;
		stayDist = 1.0f;
		move = 0;
	}
	void FixedUpdate()
	{
		headButt = Physics2D.OverlapCircle (headCheck.position, radius, whatIsPlayer);
	}
	// Update is called once per frame
	void Update () {
		dist = Vector2.Distance (transform.position, target.transform.position);
		if (frozen == false) {
						if (dist <= viewDist && dist >= stayDist && target.transform.position.y < transform.position.y + 0.3f) {
								if (target.transform.position.x > transform.position.x) {
										move = 1;
								} else if (target.transform.position.x < transform.position.x) {
										move = -1;
								} else {
										move = 0;
								}
								rigidbody2D.velocity = new Vector3 (move * speed, rigidbody2D.velocity.y);
						}
				}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player" && frozen == false) {
			PlayerMovement movement = (PlayerMovement)target.GetComponent(typeof(PlayerMovement));
			if(headButt){//target.transform.position.y > transform.position.y + 0.15f) {
				movement.bounce(3);
			} else if(target.transform.position.x > transform.position.x+0.1f) {
				movement.bounce(1);
			} else if (target.transform.position.x < transform.position.x-0.1f) {
				movement.bounce(2);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "BreathRight" && frozen == false) {
						frozen = true;
			(Instantiate (ice, transform.position, transform.rotation) as GameObject).transform.parent =  gameObject.transform;

				}
		if (other.name == "BreathLeft"&& frozen == false) {
			(Instantiate (ice, transform.position, transform.rotation) as GameObject).transform.parent =  gameObject.transform;
			frozen = true;
		}
	}
}