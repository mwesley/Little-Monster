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
	public bool canClimb;
	public bool canDoubleJump;
	bool bouncing;
	bool canJump;
	float sec;
	float cutRange;
	float t;
	private float _xFactor;

	// Use this for initialization
	void Start () {
		bouncing = false;
		canMove = true;
		canClimb = false;
		sec = 0.0f;
		cutRange = 2.0f;
		t = 0.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		if (grounded)
			canJump = true;
		if (canMove) 
		{
			InputMovement ();

			if(canClimb)
				Climb();

			if(canDoubleJump)
				DoubleJump();
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
		if (grounded && Input.GetButtonDown("Jump")) 
		{
			rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
			//jumped = true;
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
				float move = Input.GetAxis ("Horizontal");

				if (!bouncing && !PlayerStats.killed && grounded) {
						rigidbody2D.velocity = new Vector2 (move * speed, rigidbody2D.velocity.y);
				} else if (!grounded) {
						_xFactor = move * speed * 5f;
						rigidbody2D.AddForce (new Vector2 (_xFactor, 0));
						if (rigidbody2D.velocity.x >= speed) {
								rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);
						} else if (rigidbody2D.velocity.x <= -speed) {
								rigidbody2D.velocity = new Vector2 (-speed, rigidbody2D.velocity.y);
						}

				}
		}

	void Climb()
	{
		float newMove = Input.GetAxis ("Vertical");
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, newMove * speed);
	}
	void DoubleJump()
	{
		if (!grounded) 
		{
			if(canJump)
			{
				if(Input.GetButtonDown("Jump"))
				{
					//rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
					float yVelocity = rigidbody2D.velocity.y;
					float yFactor = 0;
					if(yVelocity < 0)
					{
						yFactor = -yVelocity;
					}
					rigidbody2D.AddForce(new Vector2(0f, jumpForce + yFactor), ForceMode2D.Impulse);
					canJump = false;
				}

			}
		} 
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Platform") 
		{
			Debug.Log ("I'm on a platform motherfucker!");
			transform.parent = col.transform;
		}
	}
	void OnCollisionExit2D(Collision2D col)
	{
		if(col.gameObject.tag == "Platform")
		{
			Debug.Log ("Awww....no platform....");
			transform.parent = null;
		}
	}
}