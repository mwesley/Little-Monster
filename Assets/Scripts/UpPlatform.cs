using UnityEngine;
using System.Collections;

public class UpPlatform : MonoBehaviour
{

		public Vector2 endPosition;
		public float speed;
		private float t = 0.0f;
		private bool reversing;
		private bool forwarding;
		public Vector2 startPosition;

		// Use this for initialization
		void Start ()
		{
				//test commit from uni
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void FixedUpdate ()
		{

				this.transform.position = Vector2.Lerp (startPosition, endPosition, speed * t);

				if (t >= 1f) {
						reversing = true;
						forwarding = false;
				} else if (t <= 0f) {
						reversing = false;
						forwarding = true;
				}

				if (forwarding) {
						t += Time.deltaTime;
				} else if (reversing) {
						t -= Time.deltaTime;
				}
		}
}
