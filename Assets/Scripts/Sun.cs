using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public GameObject sun;
    private bool iCT = false;
    // Start is called before the first frame update

    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        iCT = DayNightCycle.isCountingTime;
    }

    // Update is called once per frame
    void Update()
    {
        iCT = DayNightCycle.isCountingTime;
        if (iCT)
        {
            sun.transform.Rotate(0.061f, 0.0f, 0.0f, Space.World);
        }
    }
}
