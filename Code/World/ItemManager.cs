using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager: MonoBehaviour {
	public GameObject current;
	public Image questItemImage;
	public Image weaponImage;
	public Sprite hoe;
	public Sprite goodSword;
	public Sprite badSword;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other) {
		if(other.CompareTag("Player") && current.CompareTag("BadSword")) {
			PlayerPrefs.SetString ("weapon", "bs");
			weaponImage.sprite = badSword;
			current.SetActive (false);
		}
		if(other.CompareTag("Player") && current.CompareTag("GoodSword")) {
			PlayerPrefs.SetString ("weapon", "gs");
			weaponImage.sprite = goodSword;
			current.SetActive (false);
		}
		if(other.CompareTag("Player") && current.CompareTag("QuestItem")) {
			PlayerPrefs.SetString ("questItem", "hoe");
			PlayerPrefs.SetString ("gotHoe", "hoe");
			questItemImage.sprite = hoe;
			current.SetActive (false);
		}
	}
}
