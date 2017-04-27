using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager: MonoBehaviour {
	public Text noSaveTextBox;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void continueButton() {
		string scene = PlayerPrefs.GetString ("scene", "null");
		if (scene.Equals ("null") == false) {
			SceneManager.LoadScene (scene);
		} 
		else {
			noSaveTextBox.text = "No Save Found";
		}
	}

	// called when the start game button is pushed anywhere
	public void startGameButton() {
		SceneManager.LoadScene ("Village"); // loads first level
		PlayerPrefs.SetInt("gold", 0);
		PlayerPrefs.SetString ("weapon", "null");
		PlayerPrefs.SetString ("questItem", "null");
		PlayerPrefs.SetInt ("skelKillCount", 0);
		PlayerPrefs.SetString ("gotHoe", "null");
		PlayerPrefs.SetString ("Villager", "false");
		PlayerPrefs.SetString ("Brother", "false");
		PlayerPrefs.SetFloat ("playerx", 181.9f);
		PlayerPrefs.SetFloat ("playery", 58.0f);
		PlayerPrefs.SetFloat ("playerz", 33.3f);
	}

    public void playerAnim() {
        SceneManager.LoadScene("CharacterTest"); // loads first level
    }

    // called when the controls button is pushed anywhere
    public void controlsButton() {
		SceneManager.LoadScene ("Controls"); // loads the controls information scene
	}

	// called when the story is pushed anywhere
	public void storyButton() {
		SceneManager.LoadScene ("Story"); // loads the tutorial scene
	}

//	// called when the options button is pushed anywhere
//	public void optionsButton() {
//		SceneManager.LoadScene ("Options"); // loads the game options scene
//	}

	// called when the tutorial button is pushed anywhere
	public void tutorialButton() {
		SceneManager.LoadScene ("Tutorial"); // loads the tutorial scene
	}

	// called when the exit button is pushed anywhere
	public void exitButton() {
		Application.Quit (); // quits the game
	}

	// called when the play again button is pushed anywhere
	public void playAgainButton() {
		SceneManager.LoadScene ("MainMenuAlpha"); // loads the main menu scene
	}

	// called when the return to main menu button is pushed anywhere
	public void returnToMainMenuButton() {
		SceneManager.LoadScene ("Main Menu"); // loads the main menu scene
	}
}
