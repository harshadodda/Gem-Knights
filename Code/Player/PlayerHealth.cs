using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public float maximumHealth = 100f;
    public float currentHealth = 100f;

    public float healthBarLength; // REPLACE WHEN GUI IMPLEMENTED

    // Use this for initialization
    void Start()
    {
        changeHealthBarLength();  // REPLACE WHEN GUI IMPLEMENTED
    }

    // Update is called once per frame
    void Update()
    {
        AdjustCurrentHealth(0.005f);
    }

    // Adjusts health amount
    public void AdjustCurrentHealth(float adj)
    {
        currentHealth += adj;

        checkHealthBounds();

        updateHealthBar(); // REPLACE WHEN GUI IMPLEMENTED
    }

    // Error checks Health
    void checkHealthBounds()
    {
        if (currentHealth < 1)
            SceneManager.LoadScene("Defeat Screen");

        if (currentHealth > maximumHealth)
            currentHealth = maximumHealth;
    }



    /* 
     * Replace all of the below with proper GUI when it is implemented
     */

    // Creates Health Bar
    void OnGUI()
    {

        GUI.color = Color.red; // 2. apply color
        GUI.Box(new Rect(Screen.width/4, 10, healthBarLength, 20), (int)currentHealth + "/" + (int)maximumHealth);

    }

    // Changes bar length
    void changeHealthBarLength()
    {
        healthBarLength = Screen.width / 2;
    }

    void updateHealthBar()
    {
        healthBarLength = (Screen.width / 2) * ((int)currentHealth / (float)maximumHealth);
    }
}
