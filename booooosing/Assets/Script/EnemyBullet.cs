using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector2 moveDirection;
    Health health;
    [SerializeField] float damage = 100f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] ParticleSystem onHitEffect;

    



    void Awake()
    {
        health = FindObjectOfType<Health>();
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * moveDirection * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        Instantiate(onHitEffect, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            health.ReduceHealth(damage);
        }
        Destroy();
    }
}
