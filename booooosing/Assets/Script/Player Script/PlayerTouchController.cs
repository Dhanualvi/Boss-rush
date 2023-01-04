using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerTouchController : MonoBehaviour
{
    [SerializeField] FixedJoystick joystick;
    Animator myAnimator;
    PlayerShield shield;

    Player player;
    Health health;
    Rigidbody2D myRigidbody;
    Vector2 move;
    //float speed;

    bool isMoving;
    void Awake()
    {
        player = FindObjectOfType<Player>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        shield = FindObjectOfType<PlayerShield>();
        health = FindObjectOfType<Health>();
        //speed = player.GetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        
        FlipSprite();
        Run();
    }

    private void FixedUpdate()
    {
        //myRigidbody.MovePosition(myRigidbody.position + move * speed * Time.fixedDeltaTime);
    }

    void Run()
    {
        if (!health.GetIsAliveState()) 
        {
            return;
        }
        if (shield.GetShieldState())
        {
            player.SetSpeedToZero();
        }
        else
        {
           player.SetSpeedToNormal();
        }

        move.x = joystick.Horizontal;
        move.y = joystick.Vertical;
        Vector2 playerVelocity = new Vector2(move.x * player.GetSpeed(), move.y * player.GetSpeed());
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
}
