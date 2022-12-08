using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Animator myAnimator;
    [SerializeField] float startDelay = 2f;
    [SerializeField] float attackCooldown = 4f;
    [SerializeField] string bossName;   
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
        myAnimator = GetComponent<Animator>();
        StartCoroutine(SetShootingState());

    }

    private void Update()
    {
        SetCurrentPhase();
        Die();
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
        isAttackingRight = true;
        StartCoroutine(StartFireAttackCooldown());
        myAnimator.SetTrigger("isPlayerStepped");
    }
    public void BossAttackLeft()
    {
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

    IEnumerator SetShootingState()
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
            Debug.Log("Step");
            playerDetector.SetVisible(false);
            yield return new WaitForSeconds(attackCooldown);
            playerDetector.SetVisible(true);
            isAttackingRight = false;
        }
        if (isAttackingLeft)
        {
            playerDetectorTwo.SetVisible(false);
            yield return new WaitForSeconds(attackCooldown);
            playerDetectorTwo.SetVisible(true);
            isAttackingLeft = false;
        }
    }
}
