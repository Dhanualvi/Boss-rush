using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbDamage : MonoBehaviour
{

    [SerializeField] float damage = 200f;
    CapsuleCollider2D myCapsuleCollider;
    Health health;
    // Start is called before the first frame update
    void Awake()
    {
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        health = FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            health.ReduceHealth(damage);
        }
    }
}
