using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] GameObject waypointOne;
    [SerializeField] GameObject waypointTwo;
    [SerializeField] GameObject waypointThree;
    [SerializeField] GameObject waypointFour;
    [SerializeField] float speed = 1f;

    bool ready;
    bool oneTouch;
    bool twoTouch;
    bool threeTouch;
    bool fourTouch;
    
    // Start is called before the first frame update
    void Start()
    {
        ready = true;
        oneTouch = false;
        twoTouch = false;
        threeTouch = false;
        fourTouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypointOne.transform.position, speed * Time.deltaTime);
            if (transform.position == waypointOne.transform.position)
            {
                ready = false;
                oneTouch = true;
            }
        }
        if (oneTouch && !twoTouch)
        {

            transform.position = Vector2.MoveTowards(transform.position, waypointTwo.transform.position, speed * Time.deltaTime);
            if (transform.position == waypointTwo.transform.position)
            {
                oneTouch = false;
                twoTouch = true;
            }
        }
        else if (twoTouch && !threeTouch)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypointThree.transform.position, speed * Time.deltaTime);
            if (transform.position == waypointThree.transform.position)
            {
                twoTouch = false;
                threeTouch = true;
            }
        }
        else if (threeTouch && !fourTouch)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypointFour.transform.position, speed * Time.deltaTime);
            if (transform.position == waypointFour.transform.position)
            {
                threeTouch = false;
                fourTouch = true;
            }
        }
        else if (fourTouch && !oneTouch)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypointOne.transform.position, speed * Time.deltaTime);
            if(transform.position == waypointOne.transform.position)
            {
                fourTouch = false;
                oneTouch = true;
            }
        }
    }
}
