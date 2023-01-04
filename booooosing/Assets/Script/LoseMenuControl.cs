using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseMenuControl : MonoBehaviour
{
    //[SerializeField] string mainMenuScene;
    [SerializeField] GameObject loseMenu;
    
   
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button restartButton;


    Scene currentScence;
    public bool isLosing;
    Health health;

    // Start is called before the first frame update
    void Awake()
    {
        isLosing = false;
        loseMenu.SetActive(false);
        health = FindObjectOfType<Health>();
        quitButton.onClick.AddListener(OnQuitGameClick);
        mainMenuButton.onClick.AddListener(OnMainMenuClick);
        restartButton.onClick.AddListener(OnRestartClick);
        currentScence = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update()
    {
        OnLosingPopUp();

    }

    void OnLosingPopUp()
    {
        if (!health.GetIsAliveState())
        {
            StartCoroutine(DelayBeforePopup());
            if (isLosing)
            {
                Time.timeScale = 0f;
                loseMenu.SetActive(true);
            }
            
        }
        
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
        isLosing = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentScence.buildIndex);
    }

    IEnumerator DelayBeforePopup()
    {

        yield return new WaitForSeconds(0.8f);
        isLosing = true;
    }
}
