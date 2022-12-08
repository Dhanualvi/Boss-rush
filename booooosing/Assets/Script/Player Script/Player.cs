using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    float tempSpeed;
    
    //[SerializeField] float aspd = 1f;
    //[SerializeField] GameObject bullet;
    //[SerializeField] Transform gunPoint;
    [SerializeField] GameObject child;
    Animator myAnimator;
    PlayerShield shield;
    bool isMoving;

    Vector2 rawIput;
    Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        tempSpeed = speed;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        shield = FindObjectOfType<PlayerShield>();
    }

    // Update is called once per frame
    void Update()
    {
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
}
