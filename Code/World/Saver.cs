using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saver : MonoBehaviour {
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
		if(Input.GetKeyDown(KeyCode.P)) {
			PlayerPrefs.SetFloat ("playerx", player.transform.position.x);
			PlayerPrefs.SetFloat ("playery", player.transform.position.y);
			PlayerPrefs.SetFloat ("playerz", player.transform.position.z);
			PlayerPrefs.SetString ("scene", sceneName);
			SceneManager.LoadScene ("Main Menu");
		}
	}
}
