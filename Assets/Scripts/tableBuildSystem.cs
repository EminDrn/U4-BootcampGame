using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tableBuildSystem : MonoBehaviour

{
    public GameObject tableGameObject, tableArea, areaToBuy;
    public static int cost = 10;
    public int woodAmount;
    private float timeInsideCollider = 0f;  // Zamanlayıcı
    private bool isInsideCollider = false; 
    private float requiredTime = 2f;

    [SerializeField] private Slider slider;


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
        if (woodAmount >= 10)
        {
            slider.value = timeInsideCollider;
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

    public void Buy(int woodAmount)
    {
        Debug.Log("buya girdi");
        Debug.Log("sayi"+woodAmount);
        if( woodAmount>=cost)
        {
            Debug.Log("if e girdi");
            stacking.decreaiseWood(cost);
            tableGameObject.SetActive(true);
            //tableArea.transform.GetChild(0).gameObject.SetActive(true);
            tableArea.transform.GetChild(0).transform.SetParent(null,true);
            tableArea.SetActive(false);
            
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
