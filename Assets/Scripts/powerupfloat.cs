using UnityEngine;
using System.Collections;

public class powerupfloat : MonoBehaviour {

	bool floatup;
	void Start (){
		floatup = false;
	}
	void Update (){
		if(floatup)
			StartCoroutine(floatingup());
		else if(!floatup)
			StartCoroutine(floatingdown());
	}
	IEnumerator floatingup (){
		transform.position +=  new Vector3(0,0.5f,0) * Time.deltaTime;
		yield return new WaitForSeconds(1);
		floatup = false;
	}
	IEnumerator floatingdown (){
		transform.position -= new Vector3(0,0.5f,0) * Time.deltaTime;
		yield return new WaitForSeconds(1);
		floatup = true;
	}
}