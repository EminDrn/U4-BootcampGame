using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DayNightCycle : MonoBehaviour
{
    private const int TIMESCALE = 36000;
    public static bool isBoosDay;
    public static int day, hour, minute;
    public static float second;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI bossText;
    // Start is called before the first frame update
    void Start()
    {
        hour = 16;
        dayText.text = " Day: "+ day;
        timeText.text = "Time: "+ (string.Format("{0:00}:{1:00}",hour,minute));

    }

    // Update is called once per frame
    void Update()
    {
       CalculateTime(); 
       CalculateBossDay(day);
    }

    void TextCallFunction()
    {
        dayText.text = " Day: "+ day ;
        timeText.text = "Time: "+ (string.Format("{0:00}:{1:00}",hour,minute));
        if (isBoosDay== true)
        {
            bossText.text = " It's boss fight day!!!";
        }
        else
        {
            bossText.text = "";
        }

    }
    void CalculateBossDay(int day)
    {
        if((day%7)!=0 || (day ==0))
        {
            isBoosDay = false;
        }
        else
        {
            isBoosDay = true;
        }
    }

    void CalculateTime()
    {
        second += Time.deltaTime * TIMESCALE;
        if(second>=60)
        {
            minute++;
            second = 0; 
            TextCallFunction();   
        }
        else if(minute>=60)
        {
            hour++;
            minute = 0;
            TextCallFunction();
        }
        else if(hour >= 24)
        {
            day++;
            hour = 0;
            TextCallFunction();
        }
    }
}
