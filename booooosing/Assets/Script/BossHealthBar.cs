using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Unity.UI;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] GameObject flashEffect;

    [SerializeField] Slider slider;
    void Start()
    {
        slider.maxValue = 100f;
    }
    public void UpdateHealthBar(float hp)
    {
        slider.value = hp;
        
    }

    public void startFlash()
    {
        StartCoroutine(flashHealthBar());
    }

    IEnumerator flashHealthBar()
    {
        flashEffect.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        flashEffect.SetActive(false);
    }
}
