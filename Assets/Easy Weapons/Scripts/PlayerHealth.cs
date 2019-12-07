using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canDie = true;					// Whether or not this health can die
    public Image healthBar;
    public Image titanBar;
    public Text healthBarValue;
    public Text titanBarValue;


    public float startingHealth = 100.0f;       // The amount of health to start with
    public float maxHealth = 100.0f;            // The maximum amount of health
    private float currentHealth;				// The current ammount of health
    private float currentTitanBar;

    public bool replaceWhenDead = false;        // Whether or not a dead replacement should be instantiated.  (Useful for breaking/shattering/exploding effects)
    public GameObject deadReplacement;          // The prefab to instantiate when this GameObject dies
    public bool makeExplosion = false;          // Whether or not an explosion prefab should be instantiated
    public GameObject explosion;                // The explosion prefab to be instantiated

    public bool isPlayer = false;               // Whether or not this health is the player
    public GameObject deathCam;                 // The camera to activate when the player dies

    private bool dead = false;                  // Used to make sure the Die() function isn't called twice

    // Use this for initialization
    void Start()
    {
        // Initialize the currentHealth variable to the value specified by the user in startingHealth
        currentHealth = startingHealth;
        currentTitanBar = 0;


        if (healthBar != null)
        {
            healthBar.fillAmount = startingHealth / maxHealth;
        }
        if (titanBar != null)
        {
            titanBar.fillAmount = currentTitanBar;
        }


    }

    public void DecreaseHealth(float amount)
    {
        // Change the health by the amount specified in the amount variable
        currentHealth += amount;
        //healthBar.fillAmount = currentHealth / startingHealth;
        currentTitanBar += 0.1f;
        if (currentTitanBar > 1)
        {
            if (titanBar != null)
            {
                titanBar.fillAmount = 1.0f;
                currentTitanBar = 1.0f;
            }
        }
        else
        {
            if (titanBar != null)
            {
                titanBar.fillAmount = currentTitanBar;
            }
        }
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (healthBar != null)
        {
            //Debug.Log(currentHealth / maxHealth);
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }

        healthBarValue.text = "Health Bar : " + currentHealth;
        Debug.Log(currentTitanBar * 100);
        titanBarValue.text = "Titan Bar : " + (int)(currentTitanBar * 100);

        //     // If the health runs out, then Die.
        //     if (currentHealth <= 0 && !dead && canDie)
        //Die();

    }
}
