using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] float shieldDuration = 2.5f;
    [SerializeField] float shieldCooldown = 7f;
    
    SkillCooldown skillCooldownIcon;
    bool isShielded;
    bool canShield;
    float fixedShieldDuration;
    Animator myAnimator;
    Player player;
    Health health;

    void Awake()
    {
        skillCooldownIcon = FindObjectOfType<SkillCooldown>();
        isShielded = false;
        canShield = true;
        myAnimator = GetComponent<Animator>();
        player = GetComponent<Player>();
        health = FindObjectOfType<Health>();
        fixedShieldDuration = shieldDuration;
    }

    private void Update()
    {
        if (!canShield )
        {
            skillCooldownIcon.UpdateSkillCooldown(shieldCooldown);
        }
    }
    public void OnShield()
    {
        if (!health.GetIsAliveState()) { return; }
        if ( !isShielded && canShield)
        {
            //shieldCooldownIcon.UpdateShieldCooldown();
            myAnimator.SetTrigger("Shield");
            
            StartCoroutine(SetShieldedState());
            StartCoroutine(StartShieldCooldown());
        }
        else
        {
            Debug.Log("Shield is on cooldown");
        }
    }
    


    public bool GetShieldState()
    {
        return isShielded;
    }

    IEnumerator SetShieldedState()
    {
        if (canShield)
        {
            canShield = false;
            isShielded = true;
            Debug.Log("Shielded : " + isShielded);
            myAnimator.SetBool("isHoldingShield", isShielded);
            
            yield return new WaitForSeconds(shieldDuration);
            isShielded = false;
            Debug.Log("Shielded : " + isShielded);
            myAnimator.SetBool("isHoldingShield", isShielded);
        }
    }

    IEnumerator StartShieldCooldown()
    {
        if (!canShield)
        {
            
            yield return new WaitForSeconds(shieldCooldown);
            skillCooldownIcon.ResetTimerValue();
            Debug.Log("Shield is ready");
            canShield = true;
        }
    }

    public float GetShieldCooldown()
    {
        return shieldCooldown;
    }

    public bool GetCanShield()
    {
        return canShield;
    }

    public float GetShieldDuration()
    {
        return fixedShieldDuration;
    }
}
