using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZombie : MonoBehaviour
{
    public float zombiHP;
    public Animator Anim;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
       
        if(zombiHP>0){
            Debug.Log("çakışma meydana geldi zombiyle");
        if (other.CompareTag("zombie"))
        {
            Anim.SetBool("isNearZombie" , true);
            

        }
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log( "---------------------------- can gelecek " + zombiHP);
        if(zombiHP>0){
             Debug.Log("çakışma meydana geldi zombiyle");
        if (other.CompareTag("zombie"))
        {
            Anim.SetBool("isNearZombie" , true);
            
            
        }else{
            Anim.SetBool("isNearZombie" , false);
            
        }
        }else if(zombiHP <=0){
        Anim.SetBool("isNearZombie" , false);
        }

       
    }
     private void OnTriggerExit(Collider other) {
        if(zombiHP>0){
        Debug.Log("Zombie Alandan çıktı");
        Anim.SetBool("isNearZombie" , false);
        }else if(zombiHP <=0){
            Anim.SetBool("isNearZombie" , false);
        }
        
    }
    void Start()
    {
        Anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        zombiHP= ZombieControl.HP; 
        Debug.Log(zombiHP);
    }
}
