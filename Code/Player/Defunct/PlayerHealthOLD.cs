using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthOLD : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColor = new Color (1f, 0f, 0f, 0.1f);


	bool isDamaged;
	bool isDead;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isDamaged) {
			// makes the damageImage's color red so we know when the player is damaged
			damageImage.color = flashColor;
		} else {
			// changes the damageImage's color to clear effectively making it invisible
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime); 
		}
		isDamaged = false; // reset the isDamaged flag
	}

	public void takeDamage(int damageTaken) {
		isDamaged = true;
		currentHealth =- damageTaken;
		healthSlider.value = currentHealth;
		if(currentHealth <= 0 && !isDead) {
			isDead = true;
			// TODO have code for potential death animation
			// player should die here
		}
	}


	/*
	This function is only temporary and it is only for the demo. 
	This function lets us manually damage the player, again for demo purposes.
	This wont be the real damage function
	*/
	void OnTriggerStay(Collider other) {
		if (other.gameObject.CompareTag ("Enemy") && Input.GetMouseButtonDown (1)) {
			// right click to damage player
			takeDamage(20);
		}
	}
}
