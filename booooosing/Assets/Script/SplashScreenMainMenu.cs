using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenMainMenu : MonoBehaviour
{
    [SerializeField] CircleCollider2D top;
    [SerializeField] CircleCollider2D bot;
    [SerializeField] CircleCollider2D left;
    [SerializeField] CircleCollider2D right;
    [SerializeField] GameObject objTop;
    [SerializeField] GameObject objBot;
    [SerializeField] GameObject objLeft;
    [SerializeField] GameObject objRight;

    bool topTouch;
    bool botTouch;
    bool leftTouch;
    bool rightTouch;
    Rigidbody2D rigidbody2D;

    [SerializeField] float speed = 2f;
    
    // Start is called before the first frame update
    
    void Start()
    {
        topTouch = false;
        botTouch = false;
        leftTouch = false;
        rightTouch = false;
     
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
    }

    private void OnMove()
    {
        Vector2 boxHorizontalMovingVelocity = new Vector2(speed, 0f);
        Vector2 boxVerticalMovingVelocity = new Vector2(0f, speed);

        rigidbody2D.velocity = boxHorizontalMovingVelocity;

        if (top.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            objTop.SetActive(false);
            topTouch = true;

            if (botTouch)
            {
                objBot.SetActive(true);
                botTouch = false;
                
            }
            speed = -speed;
            
            rigidbody2D.velocity = boxHorizontalMovingVelocity;
        }
        else if (left.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            objLeft.SetActive(false);
            leftTouch = true;

            if (rightTouch)
            {
                objRight.SetActive(true);
                rightTouch = false;
            }
            speed = -speed;
            rigidbody2D.velocity = boxVerticalMovingVelocity;
        }
        else if (right.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            rigidbody2D.velocity = boxVerticalMovingVelocity;
            objRight.SetActive(false);
            rightTouch = true;

            if (leftTouch)
            {
                objLeft.SetActive(true);
                leftTouch = false;
            }
            //speed = -speed;
            
        }
        else if (bot.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            rigidbody2D.velocity = boxHorizontalMovingVelocity;
            objBot.SetActive(false);
            botTouch = true;

            if (topTouch)
            {
                objTop.SetActive(true);
                topTouch = false;
                
            }
            //speed = -speed;
            
        }
    }

    /* void FlipSpriteHorizontally()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rigidbody2D.velocity.x)), currentY);
        currentX = -(Mathf.Sign(rigidbody2D.velocity.x));

    }
    void FlipSpriteVertically()
    {
        transform.localScale = new Vector2(currentX,-(Mathf.Sign(rigidbody2D.velocity.y)));
        currentY = -(Mathf.Sign(rigidbody2D.velocity.y));

    }*/
}
