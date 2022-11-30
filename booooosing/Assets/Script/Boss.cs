using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Animator animator;
    [SerializeField] float startDelay = 2f;
    BossAttack attackOne;
    BossAttackTwo attackTwo;
    bool canAttack;
   

    private void Start()
    {
        attackOne = FindObjectOfType<BossAttack>();
        attackTwo = FindObjectOfType<BossAttackTwo>();
        canAttack = false;
        animator = GetComponent<Animator>();
        StartCoroutine(SetShootingState());
    }

    private void Update()
    {
        StartAttacking();
    }

    void StartAttacking()
    {
        if (canAttack)
        {
            attackOne.StartAttack();
            attackTwo.StartAttack();
        }
        
    }

    public void BossAttack()
    {
        animator.SetTrigger("isPlayerStepped");
    }
    public void BossAttackLeft()
    {
        animator.SetTrigger("isPlayerSteppedLeft");
    }

    IEnumerator SetShootingState()
    {
        if (!canAttack)
        {
            yield return new WaitForSeconds(startDelay);
            canAttack = true;
        }
        
    }
}