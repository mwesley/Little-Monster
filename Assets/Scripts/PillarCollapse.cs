using UnityEngine;
using System.Collections;

public class PillarCollapse : MonoBehaviour {

	public ShatterScheduler scheduler = null;
	public GameObject pillar;
	public float freezetime;
	public bool freezing;
	public bool pillaralive = true;
	public GameObject Iceblock;
	public bool first = false;
	public GameObject[] iceblocks;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (freezing == true) {
						freezetime -= Time.deltaTime;

				}
		if (freezetime <= 4 && freezetime >= 3 && first == false) {
						first = true;
						Instantiate (Iceblock, new Vector3 (17.5f, 8.4f, 0), Quaternion.Euler (0, 0, 15));
				}
		if(freezetime <= 3 && freezetime >= 2 && first == true) {
			first = false;
			Instantiate (Iceblock, new Vector3 (15.5f, 10.4f, 0), Quaternion.Euler (0, 0, 15));
		}
		if(freezetime <= 2 && freezetime >= 1 && first == false) {
			first = true;
			Instantiate (Iceblock, new Vector3 (12.5f, 11.4f, 0), Quaternion.Euler (0, 0, 15));
		}
		if (freezetime <= 0&&pillaralive == true) {
			iceblocks = GameObject.FindGameObjectsWithTag("EnviromentIce");
			foreach (GameObject go in iceblocks) {
				go.rigidbody2D.isKinematic = false;

			}
						pillaralive = false;
						pillar.rigidbody.useGravity = true;
						StartCoroutine (Destroy ());						
				}
		if (Input.GetButtonUp ("Fire1")) {
			freezing = false;
			
		}
	
	}


	void OnTriggerEnter2D(Collider2D other){
				if (other.name == "BreathRight") {
			freezing = true;

				}

		}
	IEnumerator Destroy()
	{

		yield return new WaitForSeconds(2);
		Destroy(gameObject);




	}
}
