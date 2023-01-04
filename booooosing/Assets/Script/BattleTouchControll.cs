using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleTouchControll : MonoBehaviour
{
    [SerializeField] Button attack;
    [SerializeField] Button shield;
    [SerializeField] Button dodge;

    PlayerAttack playerAttack;
    PlayerShield playerShield;
    PlayerRoll playerRoll;
    void Awake()
    {
        attack.onClick.AddListener(OnAttackClick);
        shield.onClick.AddListener(OnShieldClick);
        dodge.onClick.AddListener(OnDodgeClick);
        playerAttack = FindObjectOfType<PlayerAttack>();
        playerShield = FindObjectOfType<PlayerShield>();
        playerRoll = FindObjectOfType<PlayerRoll>();
    }

    // Update is called once per frame
    void OnAttackClick()
    {
        playerAttack.OnSlash();
    }
    void OnShieldClick()
    {
        playerShield.OnShield();
    }
    void OnDodgeClick()
    {
        playerRoll.OnRoll();
    }


}
