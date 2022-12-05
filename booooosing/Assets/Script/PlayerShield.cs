using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] float shieldDuratoion = 2.5f;
    [SerializeField] float shieldCooldown = 5f;
    bool isShielded;
    bool canShield;
    Animator myAnimator;
    Player player;

    void Start()
    {
        isShielded = false;
        canShield = true;
        myAnimator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }
    void OnShield(InputValue value)
    {
        if (value.isPressed && !isShielded && canShield)
        {
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
            Debug.Log("Shield is ready");
            canShield = true;
        }
    }
}
