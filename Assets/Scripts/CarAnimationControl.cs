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

    public bool isCodeActive = false;

    [SerializeField] GameObject metalLog;
    [SerializeField] GameObject spawnPos;
    [SerializeField] ParticleSystem parCar1;
    [SerializeField] ParticleSystem parCar2;
    [SerializeField] ParticleSystem parCar3;
    [SerializeField] ParticleSystem parCar4;
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

                    StartCoroutine(DropCol());

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

    private IEnumerator DropCol()
    {
        yield return new WaitForSeconds(1f);

        if (!isCodeActive)
        {
            Instantiate(metalLog, spawnPos.transform.position, Quaternion.identity);
            parCar1.transform.position = new Vector3(spawnPos.transform.position.x, spawnPos.transform.position.y + 1.5f, spawnPos.transform.position.z);
            parCar2.transform.position = new Vector3(spawnPos.transform.position.x, spawnPos.transform.position.y + 1.5f, spawnPos.transform.position.z);
            parCar3.transform.position = new Vector3(spawnPos.transform.position.x, spawnPos.transform.position.y + 1.5f, spawnPos.transform.position.z);
            parCar4.transform.position = new Vector3(spawnPos.transform.position.x, spawnPos.transform.position.y + 1.5f, spawnPos.transform.position.z);
            parCar1.Play();
            parCar2.Play();
            parCar3.Play();
            parCar4.Play();
            isCodeActive = true;
        }

        yield return new WaitForSeconds(2f);

        isCodeActive = false;
    }
}
