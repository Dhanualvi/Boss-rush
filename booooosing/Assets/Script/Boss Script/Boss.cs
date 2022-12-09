using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Animator myAnimator;
    [SerializeField] float startDelay = 0.5f;
    [SerializeField] float attackCooldown = 4f;
    [SerializeField] string bossName;
    [SerializeField] float fireAttackDamage = 100f;
    [SerializeField] float fireAttackRate = 0.5f;

    float attackingTime;

    BossAttack attackOne;
    PlayerDetector playerDetector;
    BossAttackTwo attackTwo;
    PlayerDetectorTwo playerDetectorTwo;
    BossHealth health;
    Orb orb;
    bool canAttack;
    bool isAttackingRight;
    bool isAttackingLeft;
    [SerializeField]bool isAlive;
   

    void Awake()
    {
        isAlive = true;
        orb = FindObjectOfType<Orb>();
        attackOne = FindObjectOfType<BossAttack>();
        attackTwo = FindObjectOfType<BossAttackTwo>();
        health = FindObjectOfType<BossHealth>();
        playerDetector = FindObjectOfType<PlayerDetector>();
        playerDetectorTwo = FindObjectOfType<PlayerDetectorTwo>();
        canAttack = false;
        isAttackingLeft = false;
        isAttackingRight = false;
        attackingTime = 1.5f;
        myAnimator = GetComponent<Animator>();
        //StartCoroutine(SetShootingState());

    }

    private void Update()
    {
        Die();
        if (!isAlive) { return; }
        SetCurrentPhase();
        
    }

    void SetCurrentPhase()
    {
        if (!isAlive) { return; }
        if(health.UpdateBossMovement() == 1)
        {
            orb.SetVisible(true);
        } 
        else if (health.UpdateBossMovement() == 2)
        {
            attackOne.StartAttack();
        }
        else if(health.UpdateBossMovement() == 3)
        {
            attackOne.StartAttack();
            attackTwo.StartAttack();
        }
    }
    
    public string GetBossName()
    {
        return bossName;
    }

    public void BossAttack()
    {
        if (!isAlive) { return; }
        isAttackingRight = true;
            
        StartCoroutine(StartFireAttackCooldown());
        myAnimator.SetTrigger("isPlayerStepped");
    }
    public void BossAttackLeft()
    {
        if (!isAlive) { return; }
        isAttackingLeft = true;

        StartCoroutine(StartFireAttackCooldown());
        myAnimator.SetTrigger("isPlayerSteppedLeft");
    }

    public bool GetAliveState()
    {
        return isAlive;
    }

    public void SetAliveState(bool state)
    {
        isAlive = state;
    }

    IEnumerator SetAttackingState()
    {
        if (!canAttack)
        {
            yield return new WaitForSeconds(startDelay);
            canAttack = true;
        }
    }

    public void Die()
    {
        if(health.GetCurrentHealth() <= 0)
        {
            isAlive = false;
            orb.SetVisible(false);
            myAnimator.SetBool("isDead", true);
        }
    }

    IEnumerator StartFireAttackCooldown()
    {

        if (isAttackingRight)
        {
            //Debug.Log("Step");
            playerDetector.SetVisible(false);
            yield return new WaitForSeconds(attackingTime);
            isAttackingRight = false;
            yield return new WaitForSeconds(attackCooldown);
            canAttack = false;
            playerDetector.SetVisible(true);
            
        }
        if (isAttackingLeft)
        {
            playerDetectorTwo.SetVisible(false);
            yield return new WaitForSeconds(attackingTime);
            isAttackingLeft = false;
            yield return new WaitForSeconds(attackCooldown);
            canAttack = false;
            playerDetectorTwo.SetVisible(true);
            
        }
    }

    
    public bool GetAttackingState()
    {
        if(isAttackingLeft || isAttackingRight)
        {
            return true;
        }
        return false;
    }
    
    public float getFireDamage()
    {
        return fireAttackDamage;
    }

    public float getFireDamageRate()
    {
        return fireAttackRate;
    }
}
