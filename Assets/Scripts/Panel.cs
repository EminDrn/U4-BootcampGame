using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject _panel;
    public GameObject playButton;
    public GameObject optionsButton;
    public GameObject creditsButton;
    public GameObject exitButton;

    public static bool isOpen = false;

    public void OpenPanel()
    {
        if (_panel != null)
        {
            bool isActive = _panel.activeSelf;
            
            _panel.SetActive(!isActive);

            isOpen = true;
        }

        if (isOpen)
        {
            playButton.SetActive(false);
            optionsButton.SetActive(false);
            creditsButton.SetActive(false);
            exitButton.SetActive(false);
        }
    }

    public void ExitButton()
    {
        _panel.SetActive(false);
        isOpen = false;

        if (isOpen == false)
        {
            playButton.SetActive(true);
            optionsButton.SetActive(true);
            creditsButton.SetActive(true);
            exitButton.SetActive(true);
        }
    }
}
