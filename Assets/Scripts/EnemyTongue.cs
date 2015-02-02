using UnityEngine;
using System.Collections;

public class EnemyTongue : MonoBehaviour {

	Vector2 target;			//The target location
	Vector2 returnPos;		//Where the tongue returns to
	bool firing;			//Whether the tongue is firing outwards
	bool returning;			//Whether the tongue is returning backwards
	float speed;			//How fast the tongue moves
	float distFire;			//How far the tongue can go before automatically returning
	float distRet;
	float returnRange;
	GameObject player;

	// Use this for initialization
	void Start () {
		returnPos = transform.position;
		target = returnPos;
		speed = 10.0f;
		returnRange = 0.5f;
		firing = false;
		returning = false;
		player = GameObject.FindGameObjectWithTag ("Player");
		collider2D.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		returnPos = transform.parent.transform.position;

		if (firing) {
			transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
			distFire = Vector2.Distance (transform.position, target);
			if (distFire <= returnRange) {
				firing = false;
				returning = true;
				collider2D.enabled = false;
			}
		} else if (returning) {
			transform.position = Vector2.MoveTowards (transform.position, returnPos, speed * Time.deltaTime);
			distRet = Vector2.Distance (transform.position, returnPos);
			if (distRet <= 0.0f) {
				transform.position = returnPos;
				returning = false;
			}
		}
	}

	public bool isOut() {
		if (firing || returning) {
			return true;
		} else {
			return false;
		}
	}

	public void setShooting(Vector2 newTarget) {
		target = newTarget;
		firing = true;
		collider2D.enabled = true;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Platform") {
			firing = false;
			returning = true;
			collider2D.enabled = false;
		}
		if (coll.gameObject.tag == "Player" && firing) {
			PlayerMovement movement = (PlayerMovement)player.GetComponent (typeof(PlayerMovement));
			if (player.transform.position.y > transform.position.y + 0.15f) {
				movement.bounce (3);
			} else if (player.transform.position.y > transform.position.y + 0.15f) {
				movement.bounce (4);
			} else if (player.transform.position.x > transform.position.x + 0.1f) {
				movement.bounce (1);
			} else if (player.transform.position.x < transform.position.x - 0.1f) {
				movement.bounce (2);
			}
			firing = false;
			returning = true;
			collider2D.enabled = false;
		}
	}
}