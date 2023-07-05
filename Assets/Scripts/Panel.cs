using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject _panel;

    public void OpenPanel()
    {
        if (_panel != null)
        {
            bool isActive = _panel.activeSelf;
            
            _panel.SetActive(!isActive);
        }
    }
}
