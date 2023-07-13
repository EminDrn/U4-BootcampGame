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
    public Button createZombieButtton;
    private bool isCountingTime = true;
    private bool isButtonClicked = false;
    private bool isZombieGenerated = false;
    public GameObject zombiePrefab, bossZombiePrefab;
    private float countdownTimer = 10f;
    public int zombieCount;
    // Start is called before the first frame update
    void Start()
    {
        hour = 16;
        dayText.text = " Day: "+ day;
        timeText.text = "Time: "+ (string.Format("{0:00}:{1:00}",hour,minute));
        createZombieButtton.onClick.AddListener(buttonClicked);

    }

    // Update is called once per frame
    void Update()
    {
        
        if(isCountingTime)
        {
            if(hour == 23 && minute == 58)
            {
                
                isCountingTime= false;
                createZombieButtton.gameObject.SetActive(true);
                Debug.Log(countdownTimer);
                countdownTimer -= Time.deltaTime;
                if(countdownTimer<=0f)
                {
                    if(!isButtonClicked)
                    {
                        CreateZombies();
                        isButtonClicked= false;
                    }
                }
                
            }
            CalculateTime(); 
            CalculateBossDay(day);
        }
        else{
            //Debug.Log(countdownTimer);
                countdownTimer -= Time.deltaTime;
                if(countdownTimer<=0f)
                {
                    Debug.Log("zaman doldu");
                    if(!isButtonClicked && !isZombieGenerated)
                    {
                        CreateZombies();
                        isZombieGenerated = true;
                        createZombieButtton.gameObject.SetActive(false);
                        isButtonClicked= false;
                    }
                }
        }
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
    if (second >= 60)
    {
        minute++;
        second = 0;
    }

    if (minute >= 60)
    {
        hour++;
        minute = 0;
    }

    if (hour >= 24)
    {
        day++;
        hour = 0;
    }

    TextCallFunction();
}
    private void CreateZombies()
    {
        if(day == 0)
        {
            zombieCount= 3;
        }
        else if(day == 1)
        {
            zombieCount = 5;
        }
        else if(day == 2)
        {
            zombieCount = 8;
        }
        else if(day == 3)
        {
            zombieCount = 10;
        }
        else if(day == 4)
        {
            zombieCount = 12;
        }
        else if(day == 5)
        {
            zombieCount = 15;
        }
        else if(day == 6)
        {
            zombieCount = 5;
        }
        else if(day == 7)
        {
            zombieCount = 15;
        }
        for(int a = 0; a < zombieCount; a++)
        {
            Instantiate(zombiePrefab, GetRandomPosition(), Quaternion.identity);
        }
        if(isBoosDay)
        {
            createBoss();
        }
        isZombieGenerated = true;
    }
    private void buttonClicked()
    {
        isButtonClicked = true;
        createZombieButtton.interactable = false;
        if(isButtonClicked && !isZombieGenerated)
        {
            CreateZombies();
            createZombieButtton.gameObject.SetActive(false);
            isButtonClicked= false;
        }
    }

    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-10f, 10f);
        float randomZ = Random.Range(-10f, 10f);
        return new Vector3(randomX, 0f, 0f);
    }
    private void createBoss()
    {
        Instantiate(bossZombiePrefab, GetRandomPosition(), Quaternion.identity);
    }
}
