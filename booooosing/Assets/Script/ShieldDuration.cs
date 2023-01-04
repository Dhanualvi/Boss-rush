using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldDuration : MonoBehaviour
{
    [SerializeField] Slider slider;
    PlayerShield playerShield;    
    void Start()
    {
        playerShield = FindObjectOfType<PlayerShield>();
        slider.maxValue = playerShield.GetShieldDuration();
        slider.value = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value > 0)
        {
            slider.value -= Time.deltaTime;
        }
        else
        {
            slider.value = slider.maxValue;
            gameObject.SetActive(false);

        }
        
    }
}
