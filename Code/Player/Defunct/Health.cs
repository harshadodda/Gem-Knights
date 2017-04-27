using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour {

    public Slider healthBar;
    private float flashSpeed = 5f;
    private Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public Image damageImage;

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;

    public void Start()
    {
        healthBar.value = currentHealth;
    } 

    public void TakeDamage(int amount)
    {
        damageImage.color = flashColor;

        currentHealth -= amount;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
        }
    }

    public void FixedUpdate()
    {
        damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
    }

}

