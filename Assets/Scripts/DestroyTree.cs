using UnityEngine;

public class DestroyTree : MonoBehaviour
{
    public GameObject[] agacBolumleri;
    public float waitTime = 1.5f;
    private int currentIndex = 0;
    private float timer = 0f;

   private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Player")) 
    {
        Animator otherAnimator = other.gameObject.GetComponent<Animator>();
        Debug.Log("isNearTree değeri: " + otherAnimator.GetBool("isNearTree"));
        Debug.Log("Merhaba");
        timer = 0f;
        

    }
}

private void OnTriggerStay(Collider other)
{
    
    if (other.gameObject.CompareTag("Player")) 
    {
        Animator otherAnimator = other.gameObject.GetComponent<Animator>();
        bool isNearTree = otherAnimator.GetBool("isNearTree");
        Debug.Log("isNearTree değeri: " + otherAnimator.GetBool("isNearTree"));
        Debug.Log("Merhaba   : " +timer);
        if(isNearTree){
            timer += Time.deltaTime;
            if(timer>=waitTime && currentIndex < agacBolumleri.Length ){
                Destroy(agacBolumleri[currentIndex]);
                currentIndex++;
                timer = 0f;
                            
            }
        }
            if (currentIndex == 4)
            {
                Destroy(gameObject);
            }

    }
}


}
