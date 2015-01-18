using UnityEngine;
using System.Collections;

public class Powers : MonoBehaviour {
	public GameObject ClawL;
	public GameObject ClawR;
	public GameObject ClawEffect;
	public Transform ClawSpawnL;
	public Transform ClawSpawnR;
	public Transform EffectSpawnL;
	public Transform EffectSpawnR;
		public static bool GotClaw;

	// Use this for initialization
	void Start () {
		GotClaw = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 Playerpos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 MousePosition = Input.mousePosition;

	if (Input.GetButtonDown ("Fire1")&& GotClaw == true)
		    {
			if(MousePosition.x>Playerpos.x)
			{
			GameObject clawprefab = Instantiate(ClawR, ClawSpawnR.position,Quaternion.Euler(0,0,0))as GameObject;
			clawprefab.transform.parent = transform;
			Instantiate(ClawEffect, EffectSpawnR.position,Quaternion.Euler(0,0,0));
			}
			else if (MousePosition.x<Playerpos.x)
			{
				GameObject clawprefab = Instantiate(ClawL, ClawSpawnL.position,Quaternion.Euler(0,0,0))as GameObject;
				clawprefab.transform.parent = transform;
				Instantiate(ClawEffect, EffectSpawnL.position,Quaternion.Euler(0,0,0));

			}
		}


	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "ClawPickup") {
			Powers.GotClaw = true;
			Destroy (coll.gameObject);
		}
	}

}
