using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    //[SerializeField] float aspd = 1f;
    //[SerializeField] GameObject bullet;
    //[SerializeField] Transform gunPoint;
    [SerializeField] GameObject child;
    Animator myAnimator;
    bool isMoving;

    Vector2 rawIput;
    Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
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




}
