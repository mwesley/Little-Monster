using UnityEngine;
using System.Collections;

public class ChemTank : MonoBehaviour {
	public GameObject acid;
	public Vector3 acidposition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
				if (coll.gameObject.name == "Scientist") {

						Destroy (coll.gameObject);
			acidposition = transform.position;
			acidposition.y += 1f;
			Instantiate(acid, acidposition,Quaternion.Euler(-90,0,0));
		}
		}


}
