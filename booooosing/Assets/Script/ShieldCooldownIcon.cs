using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldCooldownIcon : MonoBehaviour
{
    [SerializeField] Image shieldImage;
    //PlayerShield playerShield;
    public float fillFraction;
    float timerValue;

    private void Start()
    {
        shieldImage.fillAmount = 1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateShieldCooldown(float cd)
    {
        timerValue += Time.deltaTime;
        //Debug.Log(timerValue);
        if(timerValue <= cd)
        {
            fillFraction = timerValue/cd;
            shieldImage.fillAmount = fillFraction;  
        }

    }

    public void ResetTimerValue()
    {
        timerValue = 0; 
    }
}
