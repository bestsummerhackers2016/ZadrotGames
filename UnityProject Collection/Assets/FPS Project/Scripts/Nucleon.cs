using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Nucleon : MonoBehaviour {

		Rigidbody body;

	public	float attractionForce;
	void Start () {
		body = GetComponent<Rigidbody> ();
	}
	
		void FixedUpdate(){
		body.AddForce (transform.localPosition * -attractionForce);
		}
}
