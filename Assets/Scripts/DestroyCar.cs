using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCar : MonoBehaviour
{
    public GameObject[] arabaBolumleri;
    public float waitTime = 1.5f;
    private int currentIndex = 0;
    private float timer = 0f;

    [SerializeField] private ParticleSystem[] par_Car;
    [SerializeField] private GameObject carCol;
    [SerializeField] private Transform spawnPos;

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
        Debug.Log("isNearCar değeri: " + otherAnimator.GetBool("isNearCar"));
        Debug.Log("Merhaba");
        timer = 0f;
    }
}

private void OnTriggerStay(Collider other)
{
    if (other.gameObject.CompareTag("Player")) 
    {
        Animator otherAnimator = other.gameObject.GetComponent<Animator>();
        bool isNearCar = otherAnimator.GetBool("isNearCar");
        Debug.Log("isNearCar değeri: " + otherAnimator.GetBool("isNearCar"));
        Debug.Log("Merhaba   : " +timer);
        if (isNearCar)
        {
             Debug.Log("index ==== " + currentIndex);
            timer += Time.deltaTime;
            if (timer >= waitTime && currentIndex < arabaBolumleri.Length)
            {
               
                if(currentIndex == 0 ){
                currentIndex++;
                timer = 0f;

                }    
                else if(currentIndex > 0  && currentIndex <6){
                    arabaBolumleri[currentIndex -1 ].SetActive(false);
                    arabaBolumleri[currentIndex].SetActive(true);
                    currentIndex++;
                    timer = 0f;             
                    par_Car[0].Play();
                    par_Car[1].Play();
                    par_Car[2].Play();
                    par_Car[3].Play();
                    Instantiate(carCol, spawnPos.position, Quaternion.identity);

                }
                            
            }
        }

            if (currentIndex == 6)
            {
                Destroy(gameObject);
            }

        }
}
}

