using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject shield;
    [SerializeField] Transform bulletPoint;
    //[SerializeField] Transform shieldPoint;

    Rigidbody2D myRigidbody2D;

    bool canShoot;
    bool canShield;
    bool isShielded;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float shieldCD = 3f;
    [SerializeField] float shieldUptime = 2f;
    //[SerializeField] Transform bossLocation;


    void Start()
    {
        canShoot = true;
        canShield = true;
        isShielded = false;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        RotateAim();
    }

    void RotateAim()
    {
  
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
   
    void OnFire(InputValue value)
    {

        if (value.isPressed && canShoot && !isShielded)
        {
            StartCoroutine(AttackSpeed());
            Instantiate(bullet, bulletPoint.position, transform.rotation);
        }
    }

    void OnShield(InputValue value)
    {
        if(value.isPressed && canShield)
        {
            StartCoroutine(ShieldCooldown());
            StartCoroutine(ShieldDuration());
        }
    }

    IEnumerator AttackSpeed()
    {
        if (canShoot)
        {
            canShoot = false;
            yield return new WaitForSeconds(fireRate);
            canShoot = true;
        }
    }
    IEnumerator ShieldCooldown()
    {
        if (canShoot)
        {
            canShield = false;
            yield return new WaitForSeconds(shieldCD);
            canShield = true;
        }
    }

    IEnumerator ShieldDuration()
    {
        if (!isShielded)
        {
            shield.SetActive(true);
            isShielded = true;
            yield return new WaitForSeconds(shieldUptime);
            shield.SetActive(false);
            isShielded = false;
        }
    }

}
