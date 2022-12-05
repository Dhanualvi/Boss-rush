using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private int currentAttack = 0;
    private float timeSinceAttack = 0.0f;
    [SerializeField] float attakSpeed = 0.5f;
    Animator myAnimator;
    PlayerShield  shield;
    Player player;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        shield = FindObjectOfType<PlayerShield>();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        timeSinceAttack += Time.deltaTime;
    }

   
    
    void OnFire(InputValue value)
    {
        if (shield.GetShieldState()) { return; }
        if(value.isPressed && timeSinceAttack > attakSpeed)
        {
            player.SetSpeedToZero();
            currentAttack++;

            // Loop back to one after third attack
            if (currentAttack > 3)
                currentAttack = 1;

            // Reset Attack combo if time since last attack is too large
            if (timeSinceAttack > 1.0f)
                currentAttack = 1;

            // Call one of three attack animations "Attack1", "Attack2", "Attack3"
            myAnimator.SetTrigger("Attack" + currentAttack);

            // Reset timer
            timeSinceAttack = 0.0f;
        }
        
    }
    
}
