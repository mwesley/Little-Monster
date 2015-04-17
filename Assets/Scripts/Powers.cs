using UnityEngine;
using System.Collections;

public class Powers : MonoBehaviour {
	public GameObject ClawL;
	public GameObject ClawR;
	public GameObject ClawEffect;
	public GameObject FrostBreath;
	public GameObject BreathL;
	public GameObject BreathR;
	public Transform ClawSpawnL;
	public Transform ClawSpawnR;
	public Transform EffectSpawnL;
	public Transform EffectSpawnR;
	public static bool GotClaw;
	public bool GotFrost;

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
		if(Input.GetButtonDown("Fire1") && GotFrost == true)
		   {
			if(MousePosition.x>Playerpos.x)
			{
				(Instantiate (FrostBreath, transform.position, Quaternion.Euler(0,90,0)) as GameObject).transform.parent =  gameObject.transform;
				BreathR.SetActive(true);

			}
			else if (MousePosition.x<Playerpos.x)
			{
				(Instantiate (FrostBreath, transform.position, Quaternion.Euler(0,-90,0)) as GameObject).transform.parent =  gameObject.transform;

				BreathL.SetActive(true);

			}

		}
		if (Input.GetButtonUp ("Fire1")) {
			BreathR.SetActive(false);
			BreathL.SetActive(false);
			Destroy(GameObject.Find("FrostBreath(Clone)"));

				}


	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "ClawPickup") {
			Powers.GotClaw = true;
			Destroy (coll.gameObject);
		}
	}

}
