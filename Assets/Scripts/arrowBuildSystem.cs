using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform firstPoint;
    public GameObject arrowGameObject, arrowMachine;
    public static int woodCost = 1;
    public static int stoneCost = 1;
    public int i = 0;
    public int woodAmount;
    public int stoneAmount;
    private float timeInsideCollider = 0f;  // Zamanlayıcı
    private bool isInsideCollider = false; 
    private float requiredTime = 2f;

    IEnumerator GenerateArrow()
    {
    
        for(int a =0; a <5 ; a++)
        {
            GameObject temp = Instantiate(arrowGameObject);
            temp.transform.position = new Vector3(firstPoint.position.x,firstPoint.position.y,firstPoint.position.z-((i%5)/10f));  
            i++;
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    public void Buy(int woodAmount,int stoneAmount)
    {;
        if( (woodAmount>=woodCost)&&(stoneAmount>=stoneCost ))
        {
            stacking.decreaiseWood(woodCost);   
            stacking.decreaiseStone(stoneCost); 
            StartCoroutine(GenerateArrow());
            isInsideCollider = false;
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isInsideCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isInsideCollider = false;
            timeInsideCollider = 0f;
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
            if(timeInsideCollider>=requiredTime)
            {
                woodAmount = GetWoodCount();
                stoneAmount = GetStoneCount();
                Buy(woodAmount,stoneAmount);
            }
        }
    }
}
