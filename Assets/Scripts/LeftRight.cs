using UnityEngine;
using System.Collections;

public class LeftRight : MonoBehaviour {

	private float x;
	private float y;

	public Vector2 startingPosition;
	public Vector2 endPosition;
	public Vector2 moving;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {

		x = transform.position.x;
		y = transform.position.y;
		Vector2 pos = new Vector2 (x, y);

		if (pos.x <= startingPosition.x) {
			rigidbody2D.AddForce (moving);
						
				}
		if (pos.x >= endPosition.x) {
			rigidbody2D.AddForce (-moving);
				}



	}
}
