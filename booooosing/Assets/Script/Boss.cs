using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Animator animator;
   

    private void Start()
    {
        animator = GetComponent<Animator>();   
    }

    public void BossAttack()
    {
        animator.SetTrigger("isPlayerStepped");
    }
}
