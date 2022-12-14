using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectorThree : MonoBehaviour
{
    [SerializeField] float waitingTime = 3f;
    [SerializeField] float flameDuration = 3f;
    
    [SerializeField] GameObject flame;
    bool canAttack;
    [SerializeField] float timerValue;

    Boss boss;

    private void Awake()
    {
        boss = FindObjectOfType<Boss>();
        canAttack = false;
    }

    private void Update()
    {
        startFlameAttack();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        timerValue += Time.deltaTime;

        if (collision.tag == "Player")
        {
            
            Debug.Log("player staying");
            
            if (timerValue >= waitingTime && !canAttack)
            {
                StartCoroutine(StartFlash());
            } 
        }
    }

    void startFlameAttack()
    {
        StartCoroutine(FlameAttack());
    }

    IEnumerator StartFlash()
    {
        boss.EyeFlash();
        yield return new WaitForSeconds(0.44f);
        boss.SetFlashAvailable(false);
        canAttack = true;
    }

    IEnumerator FlameAttack()
    {
        if (canAttack)
        {
            
            flame.SetActive(true);
            yield return new WaitForSeconds(flameDuration);
            flame.SetActive(false);
            canAttack = false;
            timerValue = 0;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Player leaving");
            timerValue = 0;
        }
    }
}
