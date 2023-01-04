using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class WIPscreen : MonoBehaviour
{
    [SerializeField] GameObject wipMenu;
    [SerializeField] Button closeButton;
    // Start is called before the first frame update
    void Awake()
    {
        
        wipMenu.SetActive(false);
        closeButton.onClick.AddListener(OnCloseButtonClick);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCloseButtonClick()
    {
        wipMenu.SetActive(false);
    }
}
