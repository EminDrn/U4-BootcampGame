using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class stacking : MonoBehaviour
{
    public static int collectedWoodCount = 100;
    public static int collectedStoneCount = 0;
    public static int collectedMetalCount = 0;
    public int collectedArrowCount = 0;
    public int collectedGoldCount = 0;
    public int deneme = 0;
    public TextMeshProUGUI resourceText;

    //public AudioClip aroundTheWorld;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("wood_col"))
        {
            collectedWoodCount++; // Odun sayısını artır
            Debug.Log("Odun toplandı! Toplam odun sayısı: " + collectedWoodCount);
            resourceText.text = " Wood: "+ collectedWoodCount+ " Metal: "+collectedMetalCount+" Stone: "+collectedStoneCount+ " Gold: "+collectedGoldCount+ " Arrow: "+collectedArrowCount;
            Destroy(other.gameObject);

        }

        else if(other.CompareTag("stone_col"))
        {
            collectedStoneCount++; 
            Debug.Log("Tas toplandı! Toplam tas sayısı: " + collectedStoneCount);
            Destroy(other.gameObject);
            resourceText.text = " Wood: "+ collectedWoodCount+ " Metal: "+collectedMetalCount+" Stone: "+collectedStoneCount+ " Gold: "+collectedGoldCount+ " Arrow: "+collectedArrowCount;
        }
        else if(other.CompareTag("metal_col"))
        {
            collectedMetalCount++; 
            Debug.Log("Metal toplandı! Toplam metal sayısı: " + collectedMetalCount);
            Destroy(other.gameObject);
            resourceText.text = " Wood: "+ collectedWoodCount+ " Metal: "+collectedMetalCount+" Stone: "+collectedStoneCount+ " Gold: "+collectedGoldCount+ " Arrow: "+collectedArrowCount;
        }
        else if(other.CompareTag("gold_col"))
        {
            collectedGoldCount++; 
            Debug.Log("Altın toplandı! Toplam altın sayısı: " + collectedGoldCount);
            Destroy(other.gameObject);
            resourceText.text = " Wood: "+ collectedWoodCount+ " Metal: "+collectedMetalCount+" Stone: "+collectedStoneCount+ " Gold: "+collectedGoldCount+ " Arrow: "+collectedArrowCount;
        }
        else if(other.CompareTag("arrow"))
        {
            collectedArrowCount++; 
            Debug.Log("ok toplandı! Toplam ok sayısı: " + collectedArrowCount);
            Destroy(other.gameObject);
            resourceText.text = " Wood: "+ collectedWoodCount+ " Metal: "+collectedMetalCount+" Stone: "+collectedStoneCount+ " Gold: "+collectedGoldCount+ " Arrow: "+collectedArrowCount;
        }

    }
    public static void decreaiseWood(int cost)
    {
        collectedWoodCount-= cost;
    }
    public static void decreaiseStone(int cost)
    {
        collectedStoneCount-= cost;
    }
    void Start()
    {
        resourceText.text = " Wood: "+ collectedWoodCount+ " Metal: "+collectedMetalCount+" Stone: "+collectedStoneCount+ " Gold: "+collectedGoldCount+ " Arrow: "+collectedArrowCount;
    }
    void Update()
    {
        resourceText.text = " Wood: "+ collectedWoodCount+ " Metal: "+collectedMetalCount+" Stone: "+collectedStoneCount+ " Gold: "+collectedGoldCount+ " Arrow: "+collectedArrowCount;
    }
}
