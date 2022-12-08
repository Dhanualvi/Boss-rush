using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 0.1f;
    Boss boss;
    // Start is called before the first frame update
    void Start()
    {
        SetVisible(false);
        boss = FindObjectOfType<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
       
        RotateOrb();

    }

    public void SetVisible(bool state)
    {
        gameObject.SetActive(state);
    }

    void RotateOrb()
    {
        transform.Rotate(0f, 0f, rotateSpeed);
    }
}
