using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollision : MonoBehaviour
{
    Player player;
    BossHealth bossHealth;
    [SerializeField] GameObject hitEffectSpawnPoint;
    [SerializeField] ParticleSystem hitEffect;

    private void Awake()
    {
        bossHealth = FindObjectOfType<BossHealth>();
        player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boss")
        {
            Instantiate(hitEffect,hitEffectSpawnPoint.transform.position, hitEffectSpawnPoint.transform.rotation);
            bossHealth.ReduceHealth(player.GetDamage());
            //Debug.Log("hitting boss");
        }
    }
}
