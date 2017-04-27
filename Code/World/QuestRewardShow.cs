using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestRewardShow : MonoBehaviour {
	public GameObject reward;
	protected int skelCounter = 0;
	public GameObject current;
	public Text goldCounter;
	public Text dialogBox;
	//bool recieved = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// REDO
//		if(skelCounter > 1 && recieved == false) {
//			int gold = System.Convert.ToInt32(goldCounter.text);
//			gold += 150;
//			recieved = true;
//			goldCounter.text = gold.ToString ();
//		}
	}
}
