using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {

	public Rigidbody player; // the player object
	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody> (); // get the rigid body component of the player
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other) {
		if (other.CompareTag ("Player")) { // if the player is in the collider 
			player.AddForce (transform.up * 750); // propel the player upward in the y(green) axis	
			player.AddForce(transform.forward * 750); // prople the player forward in the z(blue) axis
		}
	}
}
