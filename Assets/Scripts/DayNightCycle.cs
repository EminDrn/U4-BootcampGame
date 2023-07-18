using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DayNightCycle : MonoBehaviour
{
    private const int TIMESCALE = 930;
    public static bool isBoosDay;
    public static int day, hour, minute;
    public static float second;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI bossText;
    public Button createZombieButtton;
    [SerializeField] public static bool isCountingTime = true;
    [SerializeField] private bool isButtonClicked = false;
    [SerializeField] private bool isZombieGenerated = false;
    [SerializeField] private bool cZButton = false;
    public GameObject zombiePrefab, bossZombiePrefab;
    public float countdownTimer = 10f;
    public int zombieCount;
    public bool zombieFight = false;

    [SerializeField] private Transform bossSpawn;

    [SerializeField] private Animator cutsceneAnim;

    [SerializeField] private Image[] greenHud;
    // Start is called before the first frame update
    void Start()
    {
        hour = 08;
        day = 1;
        dayText.text = " Day: "+ day;
        timeText.text = "Time: "+ (string.Format("{0:00}:{1:00}",hour,minute));
        createZombieButtton.onClick.AddListener(buttonClicked);

    }

    // Update is called once per frame
    void Update()
    {
        
        if(isCountingTime)
        {
            if(hour == 23 && minute == 59)
            {
                countdownTimer = 10f;
                isCountingTime= false;
                createZombieButtton.gameObject.SetActive(true);
                cZButton = true;
                Debug.Log(countdownTimer);
                countdownTimer -= Time.deltaTime;
                if(countdownTimer<=0f)
                {
                    if(!isButtonClicked)
                    {
                        CreateZombies();
                        isZombieGenerated = true;
                        isButtonClicked= false;
                        cZButton = false;
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
                        cZButton = false;
                    }
                }
            if (zombieCount== 0 && zombieFight == true && isCountingTime == false)
            {
                minute ++;
                isZombieGenerated = false;
                isCountingTime = true;
                zombieFight = false;
                
                createZombieButtton.interactable = true;
            }
        }

        /*if (zombieCount == 0 && !isCountingTime)
        {
            cZButton = false;
            if (zombieCount == 0 && !cZButton)
            {
                Debug.Log("EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
                minute += 1;
                isCountingTime = true;
            }
        }*/
        if(zombieCount < 0)
        {
            zombieCount = 0;
        }
    }

    void TextCallFunction()
    {
        dayText.text = day.ToString() ;
        timeText.text = (string.Format("{0:00}:{1:00}",hour,minute));
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
        greenHud[day-1].enabled = true;
        hour = 0;
    }

    TextCallFunction();
}
    private void CreateZombies()
    {
        zombieFight = true;
        if(day == 1)
        {
            zombieCount= 3;
        }
        else if(day == 2)
        {
            zombieCount = 5;
        }
        else if(day == 3)
        {
            zombieCount = 8;
        }
        else if(day == 4)
        {
            zombieCount = 10;
        }
        else if(day == 5)
        {
            zombieCount = 12;
        }
        else if(day == 6)
        {
            zombieCount = 15;
        }
        else if(day == 7)
        {
            zombieCount = 3;
        }
        for(int a = 0; a < zombieCount; a++)
        {
            Instantiate(zombiePrefab, GetRandomPosition(), Quaternion.identity);
        }
        if(isBoosDay)
        {
            createBoss();
            CutSceneStart();
        }
        isZombieGenerated = true;
    }
    private void buttonClicked()
    {
        isButtonClicked = true;
        createZombieButtton.interactable = false;
        createZombieButtton.gameObject.SetActive(false);

        if(isButtonClicked && !isZombieGenerated)
        {
            CreateZombies();
            isButtonClicked= false;
        }
    }

    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-10f, 10f);
        float randomZ = 11f;//Random.Range(-10f, 10f);
        return new Vector3(randomX, 0f, randomZ);
    }

    private void createBoss()
    {
        Instantiate(bossZombiePrefab, bossSpawn.transform.position, Quaternion.Euler(new Vector3(0f,180f,0f)));
    }

    public void ZombieDed()
    {
        zombieCount -= 1;
        GameObject zombieClone = GameObject.Find("El(Clone)");
        Destroy(zombieClone);
    }

    public void ZombieCountLess()
    {
        zombieCount -= 1;
    }

    public void CutSceneStart()
    {
        cutsceneAnim.Play("CutScene");
    }
}
