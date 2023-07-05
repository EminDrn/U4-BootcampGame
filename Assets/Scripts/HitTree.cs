using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTree : MonoBehaviour
{
    public GameObject[] agacBolumleri;
    public float distanceThreshold = 2f; // Ağaca olan minimum mesafe
    public float waitTime = 3f;
    private int currentIndex = 0;
    private float timer = 0f;
    private Touch _touch;
    public bool isNearCharacter = false;

    private void Update()
    {
         GameObject[] trees = GameObject.FindGameObjectsWithTag("tree");
         foreach (GameObject tree in trees)
        {
            // Karakterin ve ağacın konumları arasındaki mesafeyi hesapla
            float distanceToTree = Vector3.Distance(transform.position, tree.transform.position);
             if(Input.touchCount >0){
            _touch =Input.GetTouch(0);
            
            }
            if (distanceToTree <= distanceThreshold  && !isNearCharacter)
            {
                // Bekleme süresini başlat
                isNearCharacter = true;
                timer = 0f;
            }
             if (distanceToTree <= distanceThreshold && _touch.phase == TouchPhase.Ended)
            {
                Debug.Log("Yok etme");
                 if (isNearCharacter)
            {
                // Zamanlayıcıyı artır
                timer += Time.deltaTime;

                // Bekleme süresini kontrol et
                if (timer >= waitTime)
                {
                     if (currentIndex < agacBolumleri.Length)
                    {
                            Destroy(agacBolumleri[currentIndex]);
                            currentIndex++;
                            timer = 0f;
                            
                    }
                    
                    
                }
            }
            }
        }
       
    }
}
