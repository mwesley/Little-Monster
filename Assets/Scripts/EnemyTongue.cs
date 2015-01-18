using UnityEngine;
using System.Collections;

public class EnemyTongue : MonoBehaviour {

	Vector2 target;
	Vector2 returnPos;
	bool firing;
	bool returning;
	float speed;
	float distFire;
	float distRet;
	float returnRange;
	GameObject player;

	// Use this for initialization
	void Start () {
		returnPos = transform.position;
		target = returnPos;
		speed = 3.0f;
		returnRange = 0.5f;
		firing = false;
		returning = false;
		player = GameObject.FindGameObjectWithTag ("Player");
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
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log (coll.gameObject.name);
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
		} else if (coll.gameObject.tag == "Platform" && firing) {
			firing = false;
			returning = true;
		}
	}
}