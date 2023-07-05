using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStone : MonoBehaviour
{
    public GameObject[] kayaBolumleri;
    public float waitTime = 1.5f;
    private int currentIndex = 0;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Player")) 
    {
        Animator otherAnimator = other.gameObject.GetComponent<Animator>();
        Debug.Log("isNearStone değeri: " + otherAnimator.GetBool("isNearStone"));
        Debug.Log("Merhaba");
        timer = 0f;
        

    }
}

private void OnTriggerStay(Collider other)
{
    
    if (other.gameObject.CompareTag("Player")) 
    {
        Animator otherAnimator = other.gameObject.GetComponent<Animator>();
        bool isNearStone = otherAnimator.GetBool("isNearStone");
        Debug.Log("isNearTree değeri: " + otherAnimator.GetBool("isNearStone"));
        Debug.Log("Merhaba   : " +timer);
        if(isNearStone){
            timer += Time.deltaTime;
            if(timer>=waitTime && currentIndex < kayaBolumleri.Length ){
                Destroy(kayaBolumleri[currentIndex]);
                currentIndex++;
                timer = 0f;
                            
            }
        }

    }
}
}
