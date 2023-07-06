using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class stacking : MonoBehaviour
{
    public static int collectedWoodCount = 0;
    public int collectedStoneCount = 0;
    public int collectedMetalCount = 0;
    public int collectedGoldCount = 0;
    public int deneme = 0;
    public TextMeshProUGUI resourceText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("wood_col")) // eski isim wood
        {
            //other.gameObject.tag = "Untagged";
            collectedWoodCount++; // Odun sayısını artır
            Debug.Log("Odun toplandı! Toplam odun sayısı: " + collectedWoodCount);
            resourceText.text = " Wood: "+ collectedWoodCount+ " Metal: "+collectedMetalCount+" Stone: "+collectedStoneCount+ " Gold: "+collectedGoldCount;
            Destroy(other.gameObject);

        }

        else if(other.CompareTag("stone_col")) // eski isim stone eminin yazığı stone tagıyla çakışıyor
        {
            collectedStoneCount++; 
            Debug.Log("Tas toplandı! Toplam tas sayısı: " + collectedStoneCount);
            Destroy(other.gameObject);
            resourceText.text = " Wood: "+ collectedWoodCount+ " Metal: "+collectedMetalCount+" Stone: "+collectedStoneCount+ " Gold: "+collectedGoldCount;
        }
        else if(other.CompareTag("metal_col")) // eski isim metal
        {
            collectedMetalCount++; 
            Debug.Log("Metal toplandı! Toplam metal sayısı: " + collectedMetalCount);
            Destroy(other.gameObject);
            resourceText.text = " Wood: "+ collectedWoodCount+ " Metal: "+collectedMetalCount+" Stone: "+collectedStoneCount+ " Gold: "+collectedGoldCount;
        }
        else if(other.CompareTag("gold_col")) // eski isim gold
        {
            collectedGoldCount++; 
            Debug.Log("Altın toplandı! Toplam altın sayısı: " + collectedGoldCount);
            Destroy(other.gameObject);
            resourceText.text = " Wood: "+ collectedWoodCount+ " Metal: "+collectedMetalCount+" Stone: "+collectedStoneCount+ " Gold: "+collectedGoldCount;
        }

    }
    public static void decreaiseWood()
    {
        collectedWoodCount-= BuildSystem.cost;
    }
    void Start()
    {
        resourceText.text = " Wood: "+ collectedWoodCount+ " Metal: "+collectedMetalCount+" Stone: "+collectedStoneCount+ " Gold: "+collectedGoldCount;
    }
    void Update()
    {
        resourceText.text = " Wood: "+ collectedWoodCount+ " Metal: "+collectedMetalCount+" Stone: "+collectedStoneCount+ " Gold: "+collectedGoldCount;
    }
}
