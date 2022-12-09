using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float playerHealth = 5000f;
    float currentHealth;
    float healthPercentage;
    [SerializeField] HealthBar healthBar;

    Player player;
    PlayerRoll playerRoll;
    PlayerShield playerShield;
    Animator myAnimator;
    // Start is called before the first frame update
    void Awake()
    {
        playerRoll = FindObjectOfType<PlayerRoll>();
        player = FindObjectOfType<Player>();
        playerShield = FindObjectOfType<PlayerShield>();
        myAnimator = GetComponent<Animator>();
        currentHealth = playerHealth;
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateHealth()
    {
        healthPercentage = currentHealth / playerHealth * 100;
        healthBar.UpdateHealthBar(healthPercentage);
    }

    public void ReduceHealth(float damage)
    {
        if(playerRoll.GetRollingState() || playerShield.GetShieldState()) { return; }
        if (currentHealth > 0 )
        {
         
            currentHealth -= damage;
            UpdateHealth();
            Debug.Log(currentHealth);
        }
       
    }
    //(!playerRoll.GetRollingState() || !playerShield.GetShieldState())

    public float GetCurrentHealth()
    {
        return currentHealth;
    }


}
