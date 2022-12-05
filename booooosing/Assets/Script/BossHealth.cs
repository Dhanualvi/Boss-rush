using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossHealth : MonoBehaviour
{
    [SerializeField] float bossHealth = 100f;
    [SerializeField] TextMeshProUGUI hpValueTxt;
    float currentHealth;
    float healthPercentage;
    int phase;
    Boss boss;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = bossHealth;
        hpValueTxt.text = currentHealth.ToString();
        boss = FindObjectOfType<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int UpdateBossMovement()
    {

        healthPercentage = currentHealth / bossHealth * 100;
        if(healthPercentage >= 0)
        {
            hpValueTxt.text = healthPercentage.ToString();
        }
        else
        {
            hpValueTxt.text = "0";
        }
        
        //Debug.Log("Health : "+ healthPercentage + "%");
        if (healthPercentage >= 75f && healthPercentage <= 100f)
        {
            //Debug.Log("Phase 1 is started");
            phase = 1;
        }
        else if(healthPercentage >= 50f && healthPercentage <75f)
        {
            //Debug.Log("Phase 2 is started");
            phase = 2;
        }
        else if(healthPercentage >= 0f && healthPercentage < 50f)
        {
            //Debug.Log("Phase 3 is started");
            phase = 3;
        }
        return phase;
    }


    public void ReduceHealth(float damage)
    {
        if(currentHealth > 0)
        {
            currentHealth -= damage;
            
            Debug.Log(currentHealth);
        }
      
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
    
}
