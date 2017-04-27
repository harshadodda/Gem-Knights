using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallReset : MonoBehaviour {
	public GameObject player;
	Scene scene;
	string sceneName;
	// Use this for initialization
	void Start () {
		scene = SceneManager.GetActiveScene ();
		sceneName = scene.name;
	}
	
	// Update is called once per frame
	void Update () {
		if(sceneName.Equals("Tutorial")) {
			if(player.transform.position.y < -50) {
				SceneManager.LoadScene ("Tutorial");
			}
		}
		if (player.transform.position.y < -700) {
			SceneManager.LoadScene ("Village");
		}
	}
}
