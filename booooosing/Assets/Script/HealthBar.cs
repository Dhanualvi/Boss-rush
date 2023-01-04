using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Unity.UI;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject flashEffect;
    [SerializeField] Slider slider;

    void Awake()
    {
        slider.maxValue = 100f;
        flashEffect.SetActive(false);
    }

    public void UpdateHealthBar(float hp)
    {

        slider.value = hp;
        StartCoroutine(flashHealthBar());
    }


    IEnumerator flashHealthBar()
    {
        flashEffect.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        flashEffect.SetActive(false);
    }
}
