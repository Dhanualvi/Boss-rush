using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;
    void Awake()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnStartButtonClick() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    void OnQuitButtonClick() 
    {
        Application.Quit();
    }
}
