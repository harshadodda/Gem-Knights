using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovementNeg : MonoBehaviour {
	private float startPosition;
	public float range;

	// Use this for initialization
	void Start () {
		startPosition = transform.position.z;	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y, startPosition - ((float)Mathf.Sin(Time.time) * range));
	}
}
