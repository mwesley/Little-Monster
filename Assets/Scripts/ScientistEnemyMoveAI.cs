using UnityEngine;
using System.Collections;

public class ScientistEnemyMoveAI : MonoBehaviour {

	GameObject target;
	float speed, viewDist, move, stayDist, dist;
	bool headButt;
	public Transform headCheck;
	public LayerMask whatIsPlayer;
	float radius = 0.2f;
	public bool frozen;
	public GameObject ice;
	private Animator anim;
	public int walk = 0;
	public Vector3 iceposition;


	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player");
		anim = GetComponent<Animator>();

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
		iceposition = transform.position;

		dist = Vector2.Distance (transform.position, target.transform.position);
		if (frozen == false) {
						if (dist <= viewDist && dist >= stayDist && target.transform.position.y < transform.position.y + 0.3f) {
								if (target.transform.position.x > transform.position.x) {
										move = 1;
										walk = 1;
										transform.rotation = Quaternion.Euler (0, 0, 0);
								} else if (target.transform.position.x < transform.position.x) {
										move = -1;
										walk = 1;
										transform.rotation = Quaternion.Euler (0, 180, 0);
								} else {
										move = 0;
								}
								rigidbody2D.velocity = new Vector3 (move * speed, rigidbody2D.velocity.y);
						}
				}
		anim.SetFloat("IsWalking",walk);
		if (frozen == true) {
						walk = 0;
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
			iceposition.y -= 0.8f;
			(Instantiate (ice, iceposition, transform.rotation) as GameObject).transform.parent =  gameObject.transform;

				}
		if (other.name == "BreathLeft"&& frozen == false) {
			iceposition.y -= 0.8f;
			(Instantiate (ice, iceposition, transform.rotation) as GameObject).transform.parent =  gameObject.transform;
			frozen = true;
		}
	}
}