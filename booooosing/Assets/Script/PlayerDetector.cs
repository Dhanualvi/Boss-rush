using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    
    Boss boss;
    BossAttack attack;
    private void Start()
    {
        attack = FindObjectOfType<BossAttack>();
        boss = FindObjectOfType<Boss>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            attack.Attacking();
            boss.BossAttack();
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAA");
            
        }
    }
}
