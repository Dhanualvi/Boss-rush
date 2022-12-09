using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamager : MonoBehaviour
{
    
    //[SerializeField] float attackRate = 1f;

    bool canAttack;

    Boss boss;
    Health health;
    // Start is called before the first frame update
    void Awake()
    {
        boss = FindObjectOfType<Boss>();
        health = FindObjectOfType<Health>();
        canAttack = false;
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
           
            //damage to player with firerate
            
        }
    }

    IEnumerator StartAttack()
    {
        if (boss.GetAttackingState() && !canAttack)
        {
            canAttack = true;
            //Debug.Log("Attack");
            
            yield return new WaitForSeconds(boss.getFireDamageRate());
            health.ReduceHealth(boss.getFireDamage());
            //Debug.Log("Wait");

            canAttack = false;
        }
        
    }
}
