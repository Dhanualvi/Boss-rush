using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    [SerializeField] GameObject shieldDurationIcon;
    PlayerShield shield;
    void Awake()
    {
        shield = FindObjectOfType<PlayerShield>();
    }

    // Update is called once per frame
    void Update()
    {
        ShieldBuff();
    }

    void ShieldBuff()
    {
        if (shield.GetShieldState())
        {
            shieldDurationIcon.SetActive(true);
        }
        
    }
}
