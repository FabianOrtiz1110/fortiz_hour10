using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosGoalScript : MonoBehaviour
{
	public float startSpeed = 50f;

	void Start ()
	{
		Rigidbody rigidBody = GetComponent<Rigidbody> ();
		rigidBody.velocity = new Vector3 (startSpeed, 0, startSpeed);
	}

	public Rigidbody rb;
	
	public float maxSpeed = 10f;

void FixedUpdate() {
    if (rb.velocity.magnitude > maxSpeed) {
        rb.velocity = rb.velocity.normalized * maxSpeed;
    	}
	}

	void OnCollisionEnter(Collision otherObj) {
    if (otherObj.gameObject.tag == "Chaos") {
        Destroy(otherObj.gameObject);
    }
}

}