using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public GameObject gameplayMenuUI;
    public GameObject displayMenuUI;

    // Update is called once per frame
    void Update()
    {
        bool isEscapeKey = Input.GetKeyDown(KeyCode.Escape);
        HandlePauseMenu(isEscapeKey);
    }

    void HandlePauseMenu(bool isEscapeKey)
    {
        if (isEscapeKey)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        gameplayMenuUI.SetActive(false);
        displayMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        // SceneManager.LoadScene("Main Menu");
        Debug.Log("Main Menu...");
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game...");
        Application.Quit();
    }
}
