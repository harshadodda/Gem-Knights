using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestSystem : MonoBehaviour {
	public GameObject player; 
	public GameObject questGiver;
	public GameObject panel;
	public Text textBoxText;
	public Image questItemImage;
	public Sprite blankImage;
	public Text goldCounterText;
	protected string[] dialog = new string[100]; 
	private bool read = false;
	private int lengthOfDialog = 0;
	private int lengthOfDialogStart = 0;
	private int lengthOfDialogFinish = 0;
	string[] result;
	string[] questStart;
	string[] questFinish;
	protected bool displayText = false;
	protected bool start = true;
	protected int i = 0;

	// Use this for initialization
	void Start () {
		//parseTextFile (questGiver.name); // parses the test file for the dialog used by this object
		getDialog();
		questStart = new string[lengthOfDialogStart];
		questFinish = new string[lengthOfDialogFinish];
		for(int i = 0; i < lengthOfDialogStart; i++) {
			questStart [i] = result [i];
		}
		int counter = 0;
		for(int i = lengthOfDialogStart; i < lengthOfDialog; i++) {
			questFinish[counter] = result[i];
			counter++;
		}
	}

	// Update is called once per frame
	void Update () {
		int length = 0; 
		bool start = true;
		if(PlayerPrefs.GetString("questItem", null).Equals("hoe") || PlayerPrefs.GetString(questGiver.name).Equals("true")) {
			length = lengthOfDialogFinish;
			start = false;
		}
		else if(PlayerPrefs.GetInt("skelKillCount", 0) >= 2 || PlayerPrefs.GetString(questGiver.name).Equals("true")) {
			length = lengthOfDialogFinish;
			start = false;
		}
		else if(PlayerPrefs.GetString("weapon", "null").Equals("gs") ) {
			length = lengthOfDialogFinish;
			start = false;
		}
		else {
			length = lengthOfDialogStart;
			start = true;
		}
		if(Input.GetKeyDown(KeyCode.Q)) {
			i = 0; // set the iterator to 0
			textBoxText.text = ""; // clear out the text box
			panel.SetActive (false); // make the texy box disappear because the user wants to quit the dialog
		}
		if (i >= length - 1) { // if there is dialog left to print
			if(Input.GetKeyDown(KeyCode.F)) { // player is done talking to this object
				panel.SetActive(false); // if there is no text to be displayed, make the text box diappear
				textBoxText.text = ""; // clear out the text box
				i = 0; // reset the iterator
			}
			displayText = false; // no longer display text
			return; // dont do anything else this update
		}
		if(displayText && Input.GetKeyDown(KeyCode.F)) { // if we have things to print still and the player
			panel.SetActive(true);
			// goes to the next line of dialog
			i++; // increment the iterator
			if (start == true) {
				textBoxText.text = ""; // clear the textbox
				textBoxText.text = questGiver.name + ":\n-----------------------------------------------------\n";
				textBoxText.text += questStart [i];
				PlayerPrefs.SetString (questGiver.name, "false");
			} 
			else {
				if (i >= lengthOfDialogFinish - 1 && PlayerPrefs.GetString(questGiver.name).Equals("false") && questGiver.name.Equals("Villager")) {
					PlayerPrefs.SetInt("gold", (PlayerPrefs.GetInt("gold", 0) + 150));
					questItemImage.sprite = blankImage;
					PlayerPrefs.SetString (questGiver.name, "true");
					PlayerPrefs.SetString ("questItem", "null");
					int gold = PlayerPrefs.GetInt ("gold", 0);
					goldCounterText.text = gold.ToString();
				}
				else if (i >= lengthOfDialogFinish - 1 && PlayerPrefs.GetString(questGiver.name).Equals("false") && questGiver.name.Equals("Brother")) {
					PlayerPrefs.SetInt("gold", (PlayerPrefs.GetInt("gold", 0) + 150));
					PlayerPrefs.SetString (questGiver.name, "true");
					int gold = PlayerPrefs.GetInt ("gold", 0);
					goldCounterText.text = gold.ToString();
				}
				textBoxText.text = ""; // clear the textbox
				textBoxText.text = questGiver.name + ":\n-----------------------------------------------------\n";
				textBoxText.text += questFinish [i];
			}
		}
	}

	/*
	 * This function takes in the text file called "quests.txt" and it extracts the lines
	 * of dialog that are used by this object
	 *
	 * name: the name of the questGiver, which is the thing we search for in the text file
	 */
	void parseTextFile(string name) {
		string path = Path.Combine(Directory.GetCurrentDirectory(), "Assets/QuestText/quests.txt"); // get the path for the quests file
		string[] lines = System.IO.File.ReadAllLines (path); // extract all lines in the quests file 
		foreach (string line in lines) { // go through each line in the quests file
			if(line.Equals(name)) { // if we see the name of the quest giver, start getting dialog
				read = !read;
			}
			if(read) { // if we are currently reading quest giver dialog, save each line into an array and save the length of the dialog
				if (line.Equals ("#")) {
					start = false;
				} 
				else {
					if (start == true) {
						dialog [lengthOfDialog] = line; // save the line
						lengthOfDialog++; // update the total length of the dialog
						lengthOfDialogStart++;
					} else {
						dialog [lengthOfDialog] = line; // save the line
						lengthOfDialog++; // update the total length of the dialog
						lengthOfDialogFinish++;
					}
				}
			}
		}
		result = new string[lengthOfDialog]; // make a new string array to save dialog
		for (int i = 0; i < lengthOfDialog; i++) { 
			result [i] = dialog [i]; // copy dialog over 
		}
	}

	void getDialog() {
		string[] unfinishedResult = setDialog (questGiver.name);
		for (int i = 0; i < unfinishedResult.Length; i++) {
			if (unfinishedResult [i].Equals ("#")) {
				start = false;
			} 
			else {
				if (start == true) {
					dialog [lengthOfDialog] = unfinishedResult[i]; // save the line
					lengthOfDialog++; // update the total length of the dialog
					lengthOfDialogStart++;
				} else {
					dialog [lengthOfDialog] = unfinishedResult[i]; // save the line
					lengthOfDialog++; // update the total length of the dialog
					lengthOfDialogFinish++;
				}
			}
		}
		result = new string[lengthOfDialog]; // make a new string array to save dialog
		for (int i = 0; i < lengthOfDialog; i++) { 
			result [i] = dialog [i]; // copy dialog over 
		}
	}

	/*
	 * This function gets called once for each frame that the collider detects another object inside of it 
	 * 
	 * other: the collider of the colliding object
	 */
	void OnTriggerStay(Collider other) {
		if (other.CompareTag ("Player")) { 
			if (Input.GetKeyDown (KeyCode.F)) { // if the interact button is being pressed while in the collider
				displayText = true; // start to display the dialog we stored, it will be displayed in the update function
				panel.SetActive(true); // make the text box appear because there is something to display
			}
			// the following is for the tutorial level only
			if (Input.GetMouseButtonDown (0) && questGiver.name.Equals("Farmer")) {
				panel.SetActive (true);
				string response = questGiver.name + ":\n-----------------------------------------------------\n" +  "Hey, Ouch!"; 
				textBoxText.text = response; // print response to getting attacked
				PlayerPrefs.SetInt("gold", 0);
				PlayerPrefs.SetString ("weapon", "null");
				PlayerPrefs.SetString ("questItem", "null");
				SceneManager.LoadScene("Village"); // from the tutorial scene, load the first level
			}
		}
	}

	string[] setDialog(string name) {
		if (name.Equals ("Farmer")) {
			string[] result = {
				"",
				"Welcome to the tutorial.",
				"Lets see how your legs are moving." ,
				"Use A to turn left, use D to turn right, use W to go forward, and use S to go backward.",
				"As you have already seen, use F to interact with things in the world.",
				"Go to the glowing orb and interact with it, i've never been able to reach it maybe you can.",
				"Go to the jump pad and press space on it to jump to get there."
			};
			return result;
		} 
		else if (name.Equals ("Glowing Orb")) {
			string[] result = {
				"",
				"Hello mortal.",
				"Use the left click to attack things and use the right click to defend your self from attacks.",
				"Now do my bidding and attack the weakling farmer."
			};
			return result;
		}
		else if (name.Equals ("Villager")) {
			string[] result = {
				"",
				"Oh hello, traveler.",
				"I have lost an item of great value to me.",
				"I have lost my hoe, and without it I cannot make a living.",
				"When I last remembered, I was on an island about to take a relaxing swim.",
				"The farm would be barron without it.",
				"Can you please look around and tell me where it is?",
				"#",
				"Oh wow, you found the darn thing.",
				"I always lose this old gal.",
				"Thanks for getting it back for me.",
				"Here is your reward, I hope it is enough"
			};
			return result;
		}
		else if(name.Equals("Brother")) {
			string[] result = {
				"",
				"Hi friend!",
				"I have been noticing that my crops are being destroyed by some rowdy cave people.",
				"Can you go take care of it and knock some sense into them?",
				"#",
				"Woah man, I said knock some sense into them, not kill them.",
				"What if they had lives and families?",
				"I suppose you did fulfill my request though.",
				"Here is your reward, I hope it is enough."
			};
			return result;
		}
		else if(name.Equals("Boy")) {
			string[] result = {
				"",
				"Hi, mister.",
				"My mommy has been telling me stories about lands that have not been explored yet.",
				"I hear stories that there are 4 islands that you can get to from here.",
				"I could never explore them because mommy won't let me outside the village.",
				"Golly mister, can you go explore them and tell me about it some day?",
				"I hear there is a cool sword out there somewhere.",
				"#",
				"Wow mister, that sword is awesome!",
				"Thanks for telling me stories."
			};
			return result;
		}
		string[] none = {"no quests found"};
		return none;
	}
}
