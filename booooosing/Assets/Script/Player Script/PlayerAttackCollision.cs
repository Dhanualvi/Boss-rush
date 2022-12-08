using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollision : MonoBehaviour
{
    [SerializeField] float playerDamage = 15f;
    BossHealth bossHealth;

    private void Start()
    {
        bossHealth = FindObjectOfType<BossHealth>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boss")
        {
            bossHealth.ReduceHealth(playerDamage);
            Debug.Log("hitting boss");
        }
    }
}
