using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooldown : MonoBehaviour
{
    [SerializeField] Image skillImage;
    [SerializeField] Button skillButton;
    //PlayerShield playerShield;
    public float fillFraction;
    float timerValue;

    private void Start()
    {
        skillButton.interactable = true;
        skillImage.fillAmount = 1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void SetInteractable()
    {
        
        
    }

    public void UpdateSkillCooldown(float cd)
    {
        timerValue += Time.deltaTime;
        //Debug.Log(timerValue);
        if(timerValue <= cd)
        {
            skillButton.interactable = false;
            fillFraction = timerValue/cd;
            skillImage.fillAmount = fillFraction;
        }
        else
        {
            skillButton.interactable = true;
        }

    }

    public void ResetTimerValue()
    {
        timerValue = 0; 
    }
}
