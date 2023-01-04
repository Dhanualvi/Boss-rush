using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class BossHealth : MonoBehaviour
{
    [SerializeField] float bossHealth = 100f;
    [SerializeField] TextMeshProUGUI hpValueTxt;
    [SerializeField] TextMeshProUGUI bossName;
    float currentHealth;
    float healthPercentage;
    int phase;

    BossHealthBar healthBar;
    Boss boss;
    BossHealthBar bossHealthBar;
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = bossHealth;
        healthPercentage = currentHealth / bossHealth * 100;
        //hpValueTxt.text = currentHealth.ToString();
        boss = FindObjectOfType<Boss>();
        healthBar = FindObjectOfType<BossHealthBar>();
        bossHealthBar = FindObjectOfType<BossHealthBar>();
        bossName.text = boss.GetBossName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int UpdateBossMovement()
    {

        healthPercentage = currentHealth / bossHealth * 100;
        healthBar.UpdateHealthBar(healthPercentage);

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
        else if(healthPercentage >= 25f && healthPercentage < 50f)
        {
            //Debug.Log("Phase 3 is started");
            phase = 3;
        }
        else if(healthPercentage >= 0f && healthPercentage < 25f)
        {
            phase = 4;
        }
        
        return phase;
    }


    public void ReduceHealth(float damage)
    {
        if(currentHealth > 0)
        {
            currentHealth -= damage;

            bossHealthBar.startFlash();
            //Debug.Log(currentHealth);
        }
      
    }

    public float GetCurrentHealth()
    {

        return healthPercentage;
    }
    
}
