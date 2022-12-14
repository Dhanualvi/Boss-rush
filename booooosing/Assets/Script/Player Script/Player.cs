using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float damage = 10f;
    float tempSpeed;

    //[SerializeField] float aspd = 1f;
    //[SerializeField] GameObject bullet;
    //[SerializeField] Transform gunPoint;
    
    Animator myAnimator;
    PlayerShield shield;
    Health health;  
    bool isMoving;
    bool isAlive;

    Vector2 rawIput;
    Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        isAlive = true;
        tempSpeed = speed;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        shield = FindObjectOfType<PlayerShield>();
        health = FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        Die();
        if (!isAlive) { return; }
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        rawIput = value.Get<Vector2>();
    }

    void Run()
    {
        if (shield.GetShieldState())
        {
            SetSpeedToZero();
        }
        else
        {
            SetSpeedToNormal();
        }
        Vector2 playerVelocity = new Vector2(rawIput.x * speed, rawIput.y * speed);
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed || playerHasVerticalSpeed)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        myAnimator.SetBool("isRunning", isMoving);
        //myAnimator.SetBool("isRunning", playerHasVerticalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
            
        }
        
    }

    public void Death()
    {
        if (!isAlive)
        {
            myAnimator.SetTrigger("Death");
        }
    }

    public void Die()
    {
        if (health.GetCurrentHealth() <= 0)
        {
            isAlive = false;
            
            myAnimator.SetBool("isDead", true);
        }
    }

    public bool GetMovingState()
    {
        return isMoving;
    }

    public void SetSpeedToZero()
    {
        speed = 0f;
    }
    public void SetSpeedToNormal()
    {
        speed = tempSpeed;
    }

    public void SetAliveStatus(bool state)
    {
        isAlive = state;
    }
    public bool GetAliveStatus()
    {
        return isAlive;
    }

    public float GetDamage()
    {
        return damage;
    }
}
