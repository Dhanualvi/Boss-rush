using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDamage : MonoBehaviour
{
    Boss boss;
    Health health;
    bool canAttack;
    // Start is called before the first frame update
    void Awake()
    {
        boss = FindObjectOfType<Boss>();
        health = FindObjectOfType<Health>();
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(StartAttack());
        }
    }
    
    IEnumerator StartAttack()
    {
        if (canAttack)
        {
            canAttack = false;
            yield return new WaitForSeconds(0.35f);
            health.ReduceHealth(boss.GetFlameWallDamage());
            canAttack = true;
        }
        
    }
}
