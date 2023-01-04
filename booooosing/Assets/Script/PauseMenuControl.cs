using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuControl : MonoBehaviour
{
    //[SerializeField] string mainMenuScene;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Button pauseButton;
    [SerializeField] Button resumeButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button restartButton;


    Scene currentScence;
    public bool isPaused;
    // Start is called before the first frame update
    void Awake()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        pauseButton.onClick.AddListener(OnPauseClick);
        resumeButton.onClick.AddListener(OnResumeClick);
        quitButton.onClick.AddListener(OnQuitGameClick);
        mainMenuButton.onClick.AddListener(OnMainMenuClick);
        restartButton.onClick.AddListener(OnRestartClick);
        currentScence = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnPauseClick()
    {
        
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        
    }

    void OnResumeClick()
    {
       
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    void OnMainMenuClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    void OnQuitGameClick()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    void OnRestartClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentScence.buildIndex);
    }

}
