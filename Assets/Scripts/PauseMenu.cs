using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPause = false;

    public GameObject pauseMenuPanel;

    public GameObject pauseButton;

    public Scene _scene;

    private void Start()
    {
        _scene = SceneManager.GetActiveScene();
    }

    public void OpenPauseMenu()
    {
        if (isPause)
        {
            Continue();
        }
        else
        {
            Pause();
        }
    }

    public void Continue()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
        isPause = false;pauseButton.SetActive(true);
    }

    public void Pause()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0;
        isPause = true;
        pauseButton.SetActive(false);
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
