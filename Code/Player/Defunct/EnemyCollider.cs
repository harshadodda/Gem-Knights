using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCollider : MonoBehaviour
{
    public Text dialogue;
    bool killedEnemies = false;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    // for this to work, player must have a collider with the isTrigger set to true
    void OnTriggerStay(Collider other) { // checks if player is in contact with enemy
        if (other.gameObject.CompareTag("Enemy") && Input.GetMouseButtonDown(0)) {
            // the if statement checks if the colliding object is the Enemy 
            // and if the player pressed the left mouse click 
            other.gameObject.SetActive(false); // make the enemy disappear
            dialogue.text = "";
            killedEnemies = true;
        }

        if (other.gameObject.CompareTag("Friendly") && Input.GetMouseButtonDown(0))
        {
            if (killedEnemies == false)
             dialogue.text = "Can you go and kill those skeletons over there?";
            else
                dialogue.text = "Thank you for saving us young hero!";
        }

    }

}