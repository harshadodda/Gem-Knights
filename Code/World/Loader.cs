using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {
	public GameObject player;
	Scene scene;
	string sceneName;
	float playerx = 0.0f;
	float playery = 0.0f;
	float playerz = 0.0f;
	// Use this for initialization
	void Start () {
		
	}

	void Awake() {
		scene = SceneManager.GetActiveScene ();
		sceneName = scene.name;
		 if(sceneName.Equals("Village") == true) {
			playerx = PlayerPrefs.GetFloat ("playerx", 181.9f);
			playery = PlayerPrefs.GetFloat ("playery", 58.0f);
			playerz = PlayerPrefs.GetFloat ("playerz", 33.3f);
			player.transform.position = new Vector3(playerx, playery, playerz);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
