using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUI : MonoBehaviour {
	public Text goldText;
	public Image weaponImage;
	public Image questItemImage;
	public Sprite badSword;
	public Sprite goodSword;
	public Sprite hoe;
	protected string currentWeapon;
	protected string currentQuestItem;
	protected int currentGold;

	// Use this for initialization
	void Start () {
		currentWeapon = PlayerPrefs.GetString ("weapon");
		currentQuestItem = PlayerPrefs.GetString ("questItem");	
		currentGold = PlayerPrefs.GetInt ("gold", 0);
		goldText.text = currentGold.ToString ();
		if (currentWeapon == "bs") {
			weaponImage.sprite = badSword;
		} 
		else if (currentWeapon == "gs") {
			weaponImage.sprite = goodSword;
		} 
		else if (currentWeapon == "null") {
		}

		if(currentQuestItem == "hoe") {
			questItemImage.sprite = hoe;
		}
		else if (currentQuestItem == "null") {
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
