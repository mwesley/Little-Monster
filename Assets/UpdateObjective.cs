using UnityEngine;
using System.Collections;

public class UpdateObjective : MonoBehaviour {

	public HUDControl hudScript;
	public GameObject player;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject == player)
		{
			hudScript.curObjective++;
			Destroy(this.gameObject);
		}
	}
}
