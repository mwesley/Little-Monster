using UnityEngine;
using System.Collections;

public class KillExplosion : MonoBehaviour {

	public float duration;
	private float timer;
	
	void Update () {
		timer += Time.deltaTime;
		if(timer > duration)
		{
			KillMe();
		}
	}
	void KillMe()
	{
		Destroy (this.gameObject);
	}
}
