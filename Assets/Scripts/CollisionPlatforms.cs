using UnityEngine;
using System.Collections;

public class CollisionPlatforms : MonoBehaviour {
	
	public bool movesUp;
	public Vector2 maxHeight;
	public Vector2 minHeight;
	public bool moving;
	public float speed;
	GameObject parent;
	
	// Use this for initialization
	void Start () {
		parent = this.gameObject.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moving) 
		{
			if(movesUp)
			{
				if(parent.transform.position.y < maxHeight.y)
					parent.transform.position += Vector3.up * (Time.deltaTime*speed);
			}
			else
			{
				if(parent.transform.position.y > minHeight.y)
					parent.transform.position += Vector3.down * (Time.deltaTime*speed);
			}
		} 
		else if(!moving)
		{
			if(movesUp)
			{
				if(parent.transform.position.y > minHeight.y)
					parent.transform.position += Vector3.down * (Time.deltaTime*speed);
			}
			else
			{
				if(parent.transform.position.y < maxHeight.y)
					parent.transform.position += Vector3.up * (Time.deltaTime*speed);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			moving = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			moving = false;
		}
	}
}
