using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRoll : MonoBehaviour
{
    Animator myAnimator;
    PlayerShield shield;
    bool canRoll;
    bool isRolling;
    [SerializeField] float rollStack = 3f;
    [SerializeField] float rollCooldown = 6f;

    // Start is called before the first frame update
    void Start()
    {
        canRoll = true;
        isRolling = false;
        myAnimator = GetComponent<Animator>();
        shield = FindObjectOfType<PlayerShield>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnRoll(InputValue value)
    {
        if (value.isPressed && !shield.GetShieldState() && !isRolling && rollStack > 0)
        {
            rollStack--;
            Debug.Log("Roll Stack: " + rollStack);
            canRoll = false;
            isRolling = true;
            myAnimator.SetTrigger("Roll");
            StartCoroutine(StartRollCooldown());
            StartCoroutine(SetRollingState());
        }
        else
        {
            Debug.Log("Roll is on cooldown");
        }
    }

    public bool GetRollingState()
    {
        return isRolling;
    }

    IEnumerator StartRollCooldown()
    {
        if (!canRoll)
        {
            yield return new WaitForSeconds(rollCooldown);
            if (rollStack < 3)
            {
                rollStack++;
                Debug.Log("Roll Stack: " + rollStack);
            }
            canRoll = true;
        }
    }

    IEnumerator SetRollingState()
    {
        if (isRolling)
        {
            yield return new WaitForSeconds(0.7f);
            isRolling = false;
        }
    }
    
    public float GetCurrentRollStack()
    {
        return rollStack;
    }
}
