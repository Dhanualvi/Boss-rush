using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateOrb();
    }

    void RotateOrb()
    {
        transform.Rotate(0f, 0f, rotateSpeed);
    }
}
