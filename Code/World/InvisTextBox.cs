using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisTextBox : MonoBehaviour {
	public GameObject textBoxPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Awake() {
		textBoxPanel.SetActive (false); // makes the text box false initially
	}
}
