using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    void Start()
    {
        slider.maxValue = 100f;
    }
    public void UpdateHealthBar(float hp)
    {
        slider.value = hp;
    }
}
