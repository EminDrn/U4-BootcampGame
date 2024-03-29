using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnimationControl : MonoBehaviour
{
    public float distanceThreshold = 2f; // Ağaca olan minimum mesafe
    public float waitTime = 3f; // Bekleme süresi
    public float endWaitTime = 3.5f; // Bekleme süresi
    private Touch _touch;
    private float timer = 0f; // Zamanlayıcı
    public bool isNearCharacter = false;

    [SerializeField] private Animator anim;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Tagı "tree" olan tüm nesneleri al
        GameObject[] trees = GameObject.FindGameObjectsWithTag("tree");

        foreach (GameObject tree in trees)
        {
            // Karakterin ve ağacın konumları arasındaki mesafeyi hesapla
            float distanceToTree = Vector3.Distance(transform.position, tree.transform.position);
             if(Input.touchCount >0){
            _touch =Input.GetTouch(0);
            
            }
            // Eğer karakter ağaca yakınsa ve daha önce ağaca yakın değilse
            if (distanceToTree <= distanceThreshold  && !isNearCharacter)
            {
                // Bekleme süresini başlat
                isNearCharacter = true;
                timer = 0f;
            }
            if (distanceToTree <= distanceThreshold && _touch.phase == TouchPhase.Ended)
            {
                Debug.Log("Anim başlaması lazım");
                 if (isNearCharacter)
            {
                // Zamanlayıcıyı artır
                timer += Time.deltaTime;

                // Bekleme süresini kontrol et
                if (timer >= waitTime && timer <endWaitTime)
                {
                    // Animasyonu başlat
                    //buraya yazılacak
                    GetComponent<Animator>().SetBool("isNearTree", true);
                    Invoke("IsNearTreeFalse", 2.0f);
                    
                }
                else if(timer >= endWaitTime)
                {
                    // Bekleme süresi dolmadı, animasyonu durdur
                    GetComponent<Animator>().SetBool("isNearTree", false);
                    timer = 0f;
                }
            }
            }
            
           
        }

    }

    public void IsNearTreeFalse()
    {
        anim.SetBool("isNearTree", false);
    }

}
