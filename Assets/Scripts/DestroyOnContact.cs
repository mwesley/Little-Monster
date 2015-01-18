using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {

	public GameObject explosion;

void OnCollisionEnter(Collision collision) {
			ContactPoint contact = collision.contacts[0];
			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			Vector3 pos = contact.point;
		if (collision.collider.name != "First") {
			Instantiate (explosion, pos, rot);
			Destroy (gameObject);
		}



}
}