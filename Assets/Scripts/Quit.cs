using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        
        Debug.Log("Oyun Sona Erdi");
    }
}
