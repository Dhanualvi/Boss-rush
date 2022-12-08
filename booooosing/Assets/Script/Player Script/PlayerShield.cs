using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] float shieldDuratoion = 2.5f;
    [SerializeField] float shieldCooldown = 7f;
   ShieldCooldownIcon shieldCooldownIcon;
    bool isShielded;
    bool canShield;
    Animator myAnimator;
    Player player;

    void Awake()
    {
        shieldCooldownIcon = FindObjectOfType<ShieldCooldownIcon>();
        isShielded = false;
        canShield = true;
        myAnimator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (!canShield )
        {
            shieldCooldownIcon.UpdateShieldCooldown(shieldCooldown);
        }
    }
    void OnShield(InputValue value)
    {
        if (value.isPressed && !isShielded && canShield)
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
            myAnimator.SetBool("isHoldingShield", isShielded);
            
            yield return new WaitForSeconds(shieldDuratoion);
            isShielded = false;
            myAnimator.SetBool("isHoldingShield", isShielded);
        }
    }

    IEnumerator StartShieldCooldown()
    {
        if (!canShield)
        {
            
            yield return new WaitForSeconds(shieldCooldown);
            shieldCooldownIcon.ResetTimerValue();
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
}
