using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimationControl : MonoBehaviour
{
    public float distanceThreshold = 2f; // Ağaca olan minimum mesafe
    public float waitTime = 3f; // Bekleme süresi
    public float endWaitTime = 3.5f; // Bekleme süresi
    private Touch _touch;
    private float timer = 0f; // Zamanlayıcı
    public bool isNearCharacter = false;

    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Tagı "tree" olan tüm nesneleri al
        GameObject[] cars = GameObject.FindGameObjectsWithTag("car");

        foreach (GameObject car in cars)
        {
            // Karakterin ve ağacın konumları arasındaki mesafeyi hesapla
            float distanceToCar = Vector3.Distance(transform.position, car.transform.position);
             if(Input.touchCount >0){
            _touch =Input.GetTouch(0);
            
            }
            // Eğer karakter ağaca yakınsa ve daha önce ağaca yakın değilse
            if (distanceToCar <= distanceThreshold  && !isNearCharacter)
            {
                // Bekleme süresini başlat
                isNearCharacter = true;
                timer = 0f;
            }
            if (distanceToCar <= distanceThreshold && _touch.phase == TouchPhase.Ended)
            {
                 if (isNearCharacter)
            {
                // Zamanlayıcıyı artır
                timer += Time.deltaTime;
                // Bekleme süresini kontrol et
                if (timer >= waitTime && timer <endWaitTime)
                {
                    // Animasyonu başlat
                    GetComponent<Animator>().SetBool("isNearCar", true);
                        
                    Invoke("IsNearTreeFalse", 2.0f);

                }
                else if(timer >= endWaitTime)
                {
                    // Bekleme süresi dolmadı, animasyonu durdur
                    GetComponent<Animator>().SetBool("isNearCar", false);
                    timer = 0f;
                }
            }
            }
            
           
        }
    }
    public void IsNearTreeFalse()
    {
        anim.SetBool("isNearCar", false);
    }
}
