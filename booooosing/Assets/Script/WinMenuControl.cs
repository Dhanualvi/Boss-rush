using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenuControl : MonoBehaviour
{
    //[SerializeField] string mainMenuScene;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject wipMenu;
    [SerializeField] Button nextLvlButton;
    
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button restartButton;

    Boss boss;

    Scene currentScence;
    [SerializeField] bool isWinning;
    // Start is called before the first frame update
    void Awake()
    {
        isWinning = false;
        winMenu.SetActive(false);
        nextLvlButton.onClick.AddListener(OnNextLvlClick);
        quitButton.onClick.AddListener(OnQuitGameClick);
        mainMenuButton.onClick.AddListener(OnMainMenuClick);
        restartButton.onClick.AddListener(OnRestartClick);
        currentScence = SceneManager.GetActiveScene();
        boss = FindObjectOfType<Boss>();
    }

    // Update is called once per frame
    void Update()
    {

        OnWinningPopup();
    }

    void OnWinningPopup()
    {
        if (!boss.GetAliveState())
        {
            StartCoroutine(DelayBeforPopup());
            if (isWinning)
            {
                Time.timeScale = 0f;
                winMenu.SetActive(true);
            }
            
        }
    }

    void OnNextLvlClick()
    {
        Time.timeScale = 1f;
        wipMenu.SetActive(true);  
    }

    void OnMainMenuClick()
    {
        Time.timeScale = 1f;
        isWinning = false;
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
        isWinning = false;
        SceneManager.LoadScene(currentScence.buildIndex);
    }

    IEnumerator DelayBeforPopup()
    {
        yield return new WaitForSeconds(1f);
        isWinning = true;
    }
}
