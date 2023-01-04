using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditOne : MonoBehaviour
{
    [SerializeField] Collider2D playerDetector;
    [SerializeField] Player player;
    [SerializeField] float speed = 7f;

    Rigidbody2D myRigidbody;
    Animator myAnimation;
    // Start is called before the first frame update
    void Awake()
    {
        myAnimation = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        OnPlayerEnter();
        FlipSprite();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Debug.Log("player entered");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("player exited");
        }
    }


    void OnPlayerEnter()
    {
        if (playerDetector.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            myAnimation.SetBool("playerEnter",true);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
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
