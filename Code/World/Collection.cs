using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour {
	public Text totalGold;
	private int updatedGold;
    public AudioClip goldCoin;
    public AudioClip platCoin;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Gold")) {
			updatedGold = System.Convert.ToInt32(totalGold.text);
			updatedGold += 10;
			totalGold.text = updatedGold.ToString ();
			other.gameObject.SetActive (false);
            AudioSource.PlayClipAtPoint(goldCoin, transform.position);
			PlayerPrefs.SetInt ("gold", (PlayerPrefs.GetInt("gold", 0) + 10));
        }
		if (other.CompareTag ("Platinum")) {
			updatedGold = System.Convert.ToInt32(totalGold.text);
			updatedGold += 50;
			totalGold.text = updatedGold.ToString ();
			other.gameObject.SetActive (false);
            AudioSource.PlayClipAtPoint(platCoin, transform.position);
			PlayerPrefs.SetInt ("gold", (PlayerPrefs.GetInt("gold", 0) + 50));
        }
	}
}
