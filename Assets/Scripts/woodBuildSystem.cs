using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildSystem : MonoBehaviour

{
    //public delegate void OnBuyArea();
    //public static event OnBuyArea OnBuyingWall;
    public GameObject wallGameObject, wallArea, areaToBuy;
    public static int cost = 2;
    public int woodAmount;


    public void Buy(int woodAmount)
    {;
        Debug.Log("buya girdi");
        Debug.Log("sayi"+woodAmount);
        if( woodAmount>=cost)
        {
            Debug.Log("if e girdi");
            stacking.decreaiseWood();
            wallArea.transform.GetChild(0).gameObject.SetActive(true);
            wallArea.transform.GetChild(0).transform.SetParent(null,true);
            wallArea.SetActive(false);
            
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            woodAmount = GetScore();
            Buy(woodAmount);
            areaToBuy = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
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
        woodAmount = GetScore();
    }
    public int GetScore()
    {
        woodAmount = stacking.collectedWoodCount;
        return woodAmount;
    }
}
