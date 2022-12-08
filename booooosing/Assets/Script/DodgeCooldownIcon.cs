using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DodgeCooldownIcon : MonoBehaviour
{
    [SerializeField] Image dodgeImage;
    PlayerRoll playerRoll;
    void Awake()
    {
        playerRoll = FindObjectOfType<PlayerRoll>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDodgeCooldown();
    }

    void UpdateDodgeCooldown()
    {
        float currentStack = playerRoll.GetCurrentRollStack() / 3;
        dodgeImage.fillAmount = currentStack;
    }
}
