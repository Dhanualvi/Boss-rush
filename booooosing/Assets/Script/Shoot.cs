using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPoint;
    bool canShoot;
    [SerializeField] float fireRate = 1f;
    //[SerializeField] Transform bossLocation;


    void Start()
    {
        canShoot = true;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    void OnFire(InputValue value)
    {

        if (value.isPressed && canShoot)
        {
            StartCoroutine(AttackSpeed());
            Instantiate(bullet, bulletPoint.position, transform.rotation);
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
}
