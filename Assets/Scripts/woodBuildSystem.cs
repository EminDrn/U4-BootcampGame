using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class woodBuildSystem : MonoBehaviour

{
    //public delegate void OnBuyArea();
    //public static event OnBuyArea OnBuyingWall;
    public GameObject wallGameObject, wallArea, areaToBuy;
    public static int cost = 2;
    public int woodAmount;
    private float timeInsideCollider = 0f;  // Zamanlayıcı
    private bool isInsideCollider = false; 
    private float requiredTime = 2f;

    [SerializeField] private Slider slider;


    public void Buy(int woodAmount)
    {
        if( woodAmount>=cost)
        {
            stacking.decreaiseWood(cost);
            wallArea.transform.GetChild(0).gameObject.SetActive(true);
            wallArea.transform.GetChild(0).transform.SetParent(null,true);
            wallArea.SetActive(false);
            
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
        if (other.gameObject.CompareTag("Player"))
        {
            if (woodAmount >= 2)
            {
                slider.value = timeInsideCollider;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isInsideCollider = false;
            timeInsideCollider = 0f;
            areaToBuy = null;
            slider.value = 0f;
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
        if (isInsideCollider)
        {
            timeInsideCollider +=Time.deltaTime;

            if(timeInsideCollider >= requiredTime)
            {
                woodAmount = GetWoodCount();
                Buy(woodAmount);
            }
        }
    }
    public int GetWoodCount()
    {
        woodAmount = stacking.collectedWoodCount;
        return woodAmount;
    }
}
