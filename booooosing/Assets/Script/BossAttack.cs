using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    //[SerializeField] Transform rightGunPoint;
    //[SerializeField] Transform leftGunPoint;
    //[SerializeField] private int bulletAmount = 10;
    //[SerializeField] Transform playerLocation;
    //[SerializeField] float startAngle = 90f, endAngle = 270f;

    [SerializeField] float angle = 0f;
    [SerializeField] float angleInc = 10f;
    [SerializeField] float fireRate = 0.1f;
    [SerializeField] float fireRateInc = 0.02f;
    [SerializeField] bool reverse = false;

    bool patternOne;
    bool canShoot;
    bool patternTwo;
    
    private Vector2 bulletMoveDirection;
    void Start()
    {
        patternOne = true;
        patternTwo = false;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (patternOne)
        {
            StartCoroutine(AttackRate());
        }
    }

    IEnumerator AttackRate()
    {
        if (canShoot)
        {
            SpiralFire(angleInc);
            canShoot = false;
            yield return new WaitForSeconds(fireRate);
            if (fireRate > 0.1f)
            {
                fireRate -= fireRateInc;
            }
            canShoot = true;
        }
        

    }

    void SpiralFire(float increment)
    {
        
        for (int i = 0; i <= 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);
            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<EnemyBullet>().SetMoveDirection(bulDir);
        }

        angle += increment;

        if (!reverse)
        {
            if (angle >= 360f)
            {
                angle = 0f;
            }
        }
        else if (reverse)
        {
            if (angle <= -360f)
            {
                angle = 0f;
            }
        }
    }

}
