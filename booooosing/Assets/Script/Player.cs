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

    

    Vector2 rawIput;
    Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        rawIput = value.Get<Vector2>();
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(rawIput.x * speed, rawIput.y * speed);
        myRigidbody.velocity = playerVelocity;
        
    }

    

    
}
