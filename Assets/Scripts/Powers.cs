using UnityEngine;
using System.Collections;

public class Powers : MonoBehaviour {
	public GameObject ClawL;
	public GameObject ClawR;
	public GameObject ClawEffect;
	public GameObject FrostBreath;
	public GameObject CityFrostBreath;
	public GameObject BreathL;
	public GameObject CityBreathL;
	public GameObject BreathR;
	public GameObject CityBreathR;
	public Transform ClawSpawnL;
	public Transform ClawSpawnR;
	public Transform EffectSpawnL;
	public Transform EffectSpawnR;
	public static bool GotClaw;
	public bool GotFrost;
	public bool city;
	public float offSet;
	public CityEnergy ene;
	public float cityClawCost;
	public float cityBreathCost;
	private float timer;
	private int costInc;

	// Use this for initialization
	void Start () {
		GotClaw = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Controls ();
	}
	void Controls()
	{
		Vector3 Playerpos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 MousePosition = Input.mousePosition;
		
		if (Input.GetButtonDown ("Fire1")&& GotClaw == true && !city)
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
		if (Input.GetButtonDown ("Fire1")&& GotClaw == true && city)
		{
			if(ene.energy > cityClawCost)
			{
				ene.TakeHit(cityClawCost);
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
		if(Input.GetButtonDown("Fire1") && GotFrost == true && !city)
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
		if(Input.GetButtonDown("Fire2") && GotFrost == true && city)
		{
			if(ene.energy > cityBreathCost)
			{
				costInc = 1;
				ene.TakeHit(cityBreathCost);
				if(MousePosition.x>Playerpos.x)
				{
					(Instantiate (CityFrostBreath, new Vector3 (transform.position.x + offSet, transform.position.y, -2.5f), Quaternion.Euler(0,180,0)) as GameObject).transform.parent =  gameObject.transform;
					CityBreathR.SetActive(true);
				}
				else if (MousePosition.x<Playerpos.x)
				{
					(Instantiate (CityFrostBreath, new Vector3 (transform.position.x + -offSet, transform.position.y, -2.5f), Quaternion.Euler(0,0,0)) as GameObject).transform.parent =  gameObject.transform;
					CityBreathL.SetActive(true);
				}
			}
		}
		if (Input.GetButtonUp ("Fire1")) {
			BreathR.SetActive(false);
			BreathL.SetActive(false);
			Destroy(GameObject.Find("FrostBreath(Clone)"));
			
		}
		if (Input.GetButtonUp ("Fire2") && city) {
			CityBreathR.SetActive(false);
			CityBreathL.SetActive(false);
			Destroy(GameObject.Find("CityBreath(Clone)"));
			costInc =1;
		}
		if(city && Input.GetButton ("Fire2"))
		{
			timer += Time.deltaTime;
			if(timer > 0.5)
			{
				costInc++;
				timer = 0;
				if(ene.energy > (cityBreathCost * costInc))
				{
					ene.TakeHit(cityBreathCost*costInc);
				}
				else
				{
					Destroy(GameObject.Find("CityBreath(Clone)"));
				}
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "ClawPickup") {
			Powers.GotClaw = true;
			Destroy (coll.gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "ClawPickup")
		{
			Destroy (col.gameObject);
		}
	}

}
