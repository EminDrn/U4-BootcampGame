using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrowWorkshopBuild : MonoBehaviour

{
    public GameObject weaponWorkshopGameObject, weaponWorkshopArea, areaToBuy;
    public static int woodCost = 10;
    public static int stoneCost = 5;
    public int woodAmount;
    public int stoneAmount;
    private float timeInsideCollider = 0f;  // Zamanlayıcı
    private bool isInsideCollider = false; 
    private float requiredTime = 2f;

    [SerializeField] private Slider slider;


    public void Buy(int woodAmount, int stoneAmount)
    {;
        if( (woodAmount>=woodCost)&&(stoneAmount>=stoneCost))
        {
            stacking.decreaiseWood(woodCost);
            stacking.decreaiseStone(stoneCost);
            weaponWorkshopArea.transform.GetChild(0).gameObject.SetActive(true);
            weaponWorkshopArea.transform.GetChild(0).transform.SetParent(null,true);
            weaponWorkshopArea.SetActive(false);
            
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isInsideCollider = true;
            areaToBuy = this.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        slider.value = timeInsideCollider;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isInsideCollider = false;
            timeInsideCollider = 0f;
            areaToBuy = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        woodAmount = GetWoodCount();
        stoneAmount = GetStoneCount();
        if (isInsideCollider)
        {
            timeInsideCollider +=Time.deltaTime;
            if(timeInsideCollider >= requiredTime)
            {
                woodAmount = GetWoodCount();
                stoneAmount = GetStoneCount();
                Buy(woodAmount,stoneAmount);
            }
        }

    }
    public int GetWoodCount()
    {
        woodAmount = stacking.collectedWoodCount;
        return woodAmount;
    }
    public int GetStoneCount()
    {
        stoneAmount = stacking.collectedStoneCount;
        return stoneAmount;
    }
}
