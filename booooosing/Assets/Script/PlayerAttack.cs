using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private int currentAttack = 0;
    private float timeSinceAttack = 0.0f;
    bool isAttacking;

    [SerializeField] float attackSpeed = 0.5f;
    Animator myAnimator;
    PlayerShield  shield;
    Player player;
    [SerializeField] GameObject attackCollision;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        shield = FindObjectOfType<PlayerShield>();
        player = FindObjectOfType<Player>();
        
        isAttacking = false;
    }

    private void Update()
    {
        timeSinceAttack += Time.deltaTime;
    }

   
    
    void OnFire(InputValue value)
    {
        if (shield.GetShieldState()) { return; }
        if(value.isPressed && timeSinceAttack > attackSpeed)
        {
            
            currentAttack++;

            // Loop back to one after third attack
            if (currentAttack > 3)
                currentAttack = 1;

            // Reset Attack combo if time since last attack is too large
            if (timeSinceAttack > 1.0f)
                currentAttack = 1;

            // Call one of three attack animations "Attack1", "Attack2", "Attack3"
            myAnimator.SetTrigger("Attack" + currentAttack);
            StartCoroutine(SetAttackingState());

            // Reset timer
            timeSinceAttack = 0.0f;
        }
        
    }

    IEnumerator SetAttackingState()
    {
        if(!isAttacking)
        {
            isAttacking = true;
            attackCollision.SetActive(true);
            yield return new WaitForSeconds(attackSpeed);
            attackCollision.SetActive(false);
            isAttacking = false;
        }
        
    }
    
}
