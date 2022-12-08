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
    // Start is called before the first frame update
    void Start()
    {
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
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            UpdateHealth();
            Debug.Log(currentHealth);
        }

    }
}
