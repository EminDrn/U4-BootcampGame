using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private Scene _scene;

    private void Start()
    {
        _scene = SceneManager.GetActiveScene();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(_scene.buildIndex + 1);
    }
}
