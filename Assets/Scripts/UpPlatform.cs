using UnityEngine;
using System.Collections;

public class UpPlatform : MonoBehaviour
{
	
		public Vector2 resetPosition;
		public Vector2 endPosition;
		public bool up;
		public bool down;
		public bool left;
		public bool right;
		private float x;
		private float y;
		public float speed;
    public bool timeIt;
		private float xSpeed;
    private float t = 0.0f;
		// Use this for initialization
		void Start ()
		{
				
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (up) {
						transform.position += Vector3.up * (Time.deltaTime*speed);
				}
				if (down) {
						transform.position += Vector3.down * (Time.deltaTime*speed);
				}
				if (left) {
						transform.position += Vector3.left * (Time.deltaTime*speed);
				}
				if (right) {
						transform.position += Vector3.right * (Time.deltaTime*speed);
				}




	
		}

        private void UpDownLeftRight(Vector2 pos)
        {
            if (up)
            {
                if (pos.y >= endPosition.y)
                {
                    this.gameObject.transform.position = new Vector3(resetPosition.x, resetPosition.y, 2.0f);
                }
            }

            if (down)
            {
                if (pos.y <= endPosition.y)
                {
                    this.gameObject.transform.position = new Vector3(resetPosition.x, resetPosition.y, 2.0f);
                }
            }

            if (left)
            {
                if (pos.x <= endPosition.x)
                {
                    this.gameObject.transform.position = new Vector3(resetPosition.x, resetPosition.y, 2.0f);
                }
            }

            if (right)
            {
                if (pos.x >= endPosition.x)
                {
                    this.gameObject.transform.position = new Vector3(resetPosition.x, resetPosition.y, 2.0f);
                }
            }

        }

		void FixedUpdate ()
		{

				x = transform.position.x;
				y = transform.position.y;
				Vector2 pos = new Vector2 (x, y);
            if(timeIt) {
                t += Time.deltaTime;
                if (t > 1.0f) {
                    UpDownLeftRight(pos);
				}
            }else {
                UpDownLeftRight(pos);
            }



		}
}
