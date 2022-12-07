using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    
    Boss boss;
    BossAttack attackOne;
    BossAttackTwo attackTwo;
    

    private void Awake()
    {
        
        attackOne = FindObjectOfType<BossAttack>();
        attackTwo = FindObjectOfType<BossAttackTwo>();
        boss = FindObjectOfType<Boss>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !attackOne.GetAttackingState())
        {
           
            attackOne.Attacking();
            attackTwo.Attacking();
            boss.BossAttack();
            

        }
    }

    public void SetVisible(bool state)
    {
        
        gameObject.SetActive(state);
    }
}
