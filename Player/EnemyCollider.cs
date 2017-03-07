using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	// for this to work, player must have a collider with the isTrigger set to true
	void OnTriggerStay(Collider other) { // checks if player is in contact with enemy
		if (other.gameObject.CompareTag ("Enemy") && Input.GetMouseButtonDown(0)) {
			// the if statement checks if the colliding object is the Enemy 
			// and if the player pressed the left mouse click 
			other.gameObject.SetActive (false); // make the enemy disappear
		}
	}
}
