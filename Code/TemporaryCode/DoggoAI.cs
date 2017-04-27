using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoggoAI : MonoBehaviour {
	public GameObject player;
	public GameObject doggo;
	bool follow = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (player.transform.position, doggo.transform.position);
		if (dist < 30.0 && dist > 10.0 && follow == true) {
			doggo.transform.position = Vector3.MoveTowards (doggo.transform.position, player.transform.position, 0.3f);
		}
	}

	void OnTriggerEnter(Collider other) {
		print ("Hi");
		if (other.CompareTag ("Stop")) {
			doggo.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			doggo.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
			follow = false;
		}
	}
}
