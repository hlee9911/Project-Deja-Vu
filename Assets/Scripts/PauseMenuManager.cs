using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public string sceneLoad;

    public static bool isGamePaused = false;

    public GameObject pauseMenuPanel;

    public GameObject pausemenuOptions;

    public GameObject pausemenuSettings;

    public void QuitGame()
    {
        isGamePaused = false;
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        PlayerData.isGameStarted = false;
        isGamePaused = false;
        SceneManager.LoadScene(sceneLoad);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseMenuPanel.SetActive(false);
        isGamePaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        pauseMenuPanel.SetActive(true);
        pausemenuOptions.SetActive(true);
        pausemenuSettings.SetActive(false);
        isGamePaused = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // if game is paused
            if (isGamePaused)
            {
                Resume();
            }
            // if game is not paused
            else
            {
                Pause();
            }
        }
    }
}
