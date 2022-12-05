using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Animator myAnimator;
    [SerializeField] float startDelay = 2f;
    BossAttack attackOne;
    BossAttackTwo attackTwo;
    BossHealth health;
    Orb orb;
    bool canAttack;
    [SerializeField]bool isAlive;
   

    private void Start()
    {
        isAlive = true;
        attackOne = FindObjectOfType<BossAttack>();
        attackTwo = FindObjectOfType<BossAttackTwo>();
        canAttack = false;
        
        myAnimator = GetComponent<Animator>();
        StartCoroutine(SetShootingState());
        health = FindObjectOfType<BossHealth>();
        orb = FindObjectOfType<Orb>();
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
    

    public void BossAttack()
    {
        myAnimator.SetTrigger("isPlayerStepped");
    }
    public void BossAttackLeft()
    {
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

    
}
