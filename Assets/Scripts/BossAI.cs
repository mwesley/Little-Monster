using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {

	GameObject target;		//The player
	bool canAttack;			//Whether the boss can shoot again yet
	bool canBeHit;			//Whether the tongue is out or not
	float attackCooldown;	//How often the boss can attack
	float cooldownTimer;	//The timer used for the cooldown
	float tongueRange;		//The distance the boss starts to shoot at
	float dist;				//The distance from player to boss
	EnemyTongue tongueScript;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");
		tongueRange = 5.0f;
		attackCooldown = 1.0f;
		cooldownTimer = 0.0f;
		dist = 0.0f;
		canAttack = true;
		renderer.material.color = Color.blue;
		tongueScript = (EnemyTongue)GetComponentInChildren<EnemyTongue> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (tongueScript.isOut ()) {
			canBeHit = true;
			renderer.material.color = Color.red;
		} else {
			canBeHit = false;
			renderer.material.color = Color.blue;
		}

		if (!canAttack && !tongueScript.isOut()) {
			cooldownTimer += Time.deltaTime;
			if (cooldownTimer >= attackCooldown) {
				canAttack = true;
				cooldownTimer = 0.0f;
			}
		}

		dist = Vector2.Distance (transform.position, target.transform.position);
		if (dist <= tongueRange && canAttack && !tongueScript.isOut()) {
			canAttack = false;
			tongueScript.setShooting (target.transform.position);
		}
	}


	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Spike") {
			if(canBeHit) {
				Destroy(gameObject);
			}
			SpikeScript tempScript = (SpikeScript)coll.gameObject.GetComponent(typeof(SpikeScript));
			tempScript.destroySpike();
		}
	}
}