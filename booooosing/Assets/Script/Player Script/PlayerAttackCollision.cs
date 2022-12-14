using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollision : MonoBehaviour
{
    Player player;
    BossHealth bossHealth;

    private void Awake()
    {
        bossHealth = FindObjectOfType<BossHealth>();
        player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boss")
        {
            bossHealth.ReduceHealth(player.GetDamage());
            //Debug.Log("hitting boss");
        }
    }
}
