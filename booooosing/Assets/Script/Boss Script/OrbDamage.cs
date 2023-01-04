using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbDamage : MonoBehaviour
{

    [SerializeField] float damage = 200f;
    [SerializeField] ParticleSystem onHitEffect;
    Health health;
    Boss boss;
    // Start is called before the first frame update
    void Awake()
    {
        
        health = FindObjectOfType<Health>();
        boss = FindObjectOfType<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!boss.GetAliveState()) { return; }
        if(collision.tag == "Player")
        {
            
            Instantiate(onHitEffect, transform.position, transform.rotation);
            health.ReduceHealth(damage);
        }
    }
}
