using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 100f;
	public bool canMove;
	bool bouncing;
	float sec;
	float cutRange;
	float t;

	// Use this for initialization
	void Start () {
		bouncing = false;
		canMove = true;
		sec = 0.0f;
		cutRange = 2.0f;
		t = 0.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		if (canMove) 
		{
			InputMovement ();
			inputControl ();
		}
		else 
		{
			t += Time.deltaTime;
			if(t > 1.0f)
			{
				canMove = true;
				t = 0.0f;
			}
		}
	}

	void Update()
	{
		if (grounded && Input.GetKeyDown(KeyCode.Space)) 
		{
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		}
		if (bouncing) {
			sec += Time.deltaTime;
			if(sec >= 0.6f) {
				bouncing = false;
				sec = 0.0f;
			}
		}
	}
	public void bounce(int side) {
		switch (side) {
		case 1:
			rigidbody2D.velocity = Vector3.zero;
			rigidbody2D.AddForce(new Vector3(650.0f, 100.0f, 0.0f));
			bouncing = true;
			break;
		case 2:
			rigidbody2D.velocity = Vector3.zero;
			rigidbody2D.AddForce(new Vector3(-650.0f, 100.0f, 0.0f));
			bouncing = true;
			break;
		case 3:
			rigidbody2D.velocity = Vector3.zero;
			rigidbody2D.AddForce(new Vector3(0.0f, 300.0f, 0.0f));
			break;
		case 4:
			rigidbody2D.velocity = Vector3.zero;
			rigidbody2D.AddForce(new Vector3(-650.0f, 100.0f, 0.0f));
			break;
		}
	}

	void InputMovement()
	{
		if (!bouncing) {
			float move = Input.GetAxis ("Horizontal");
			rigidbody2D.velocity = new Vector2 (move * speed, rigidbody2D.velocity.y);
		}
	}

	void inputControl() {
		if (Input.GetKeyDown (KeyCode.E)) {
			GameObject[] ropelist = GameObject.FindGameObjectsWithTag("Spike");
			foreach(GameObject ropes in ropelist) {
				float dis = Vector2.Distance(transform.position, ropes.transform.position);
				if(dis <= cutRange) {
					SpikeScript scriptTemp = (SpikeScript)ropes.GetComponentInParent(typeof(SpikeScript));
					scriptTemp.cutRope();
				}
			}
		}
	}

}