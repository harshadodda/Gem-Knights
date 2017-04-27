using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
	public Text skeletonKillCounter; // Harshas skeleton kill quest test code
    public int maximumHealth = 100;
    public int currentHealth = 100;
    EnemyAI_Skeleton AI;
    public bool alive = true;

    public float healthBarLength; // REPLACE WHEN GUI IMPLEMENTED

    // Use this for initialization
    void Start()
    {
        AI = this.GetComponent<EnemyAI_Skeleton>();
        //changeHealthBarLength();  // REPLACE WHEN GUI IMPLEMENTED
    }

    // Update is called once per frame
    void Update()
    {
        AdjustCurrentHealth(0);
    }

    // Adjusts health amount
    public void AdjustCurrentHealth(int adj)
    {
        currentHealth += adj;
        if (adj < 0) AI.damaged = true;

        checkHealthBounds();

       // updateHealthBar(); // REPLACE WHEN GUI IMPLEMENTED
    }

    // Error checks Health
    void checkHealthBounds()
    {
        if (currentHealth < 1)
        {
            currentHealth = 0;
          
            //// start of harshas test skeleton kiling quest code
            //int count = System.Convert.ToInt32(skeletonKillCounter.text);
            //count++;
            //skeletonKillCounter.text = count.ToString();
            //// end of harshas test skeleton kiling quest code
            AI.alive = false;
            //alive = false;
        }

        if (currentHealth > maximumHealth)
            currentHealth = maximumHealth;
    }



    /* 
     * Replace all of the below with proper GUI when it is implemented
     */

    // Creates Health Bar
    void OnGUI()
    {
       // GUI.Box(new Rect(10, Screen.height - 80, healthBarLength, 20), currentHealth + "/" + maximumHealth);
    }

    // Changes bar length
    void changeHealthBarLength()
    {
        healthBarLength = Screen.width / 2;
    }

    void updateHealthBar()
    {
        healthBarLength = (Screen.width / 2) * (currentHealth / (float)maximumHealth);
    }
}
