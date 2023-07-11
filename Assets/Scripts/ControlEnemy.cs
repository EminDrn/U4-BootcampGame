using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControlEnemy : MonoBehaviour
{
    public float zombiHP;
    public Animator zombieAnim;
    public Animator karakterAnim;

    public bool zombiOlu;
    public GameObject hedefOyuncu;
    public GameObject hedefOyuncu1;

    public  float mesafe;
     public float kovalamaMesafe;
     NavMeshAgent zombieNavMesh;
     public float saldirmaMesafesi;
     
     

    // Start is called before the first frame update
    void Start()
    {
        zombieAnim = this.GetComponent<Animator>();
        hedefOyuncu = GameObject.Find("Slow Run");
        karakterAnim = hedefOyuncu.GetComponent<Animator>();
        zombieNavMesh =  this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        zombiHP= ZombieControl.HP; 
        Debug.Log(zombiHP);
        // Debug.Log(hedefOyuncu.HpDondur() +"-sddadasda----");
       

        //zombieAnim.SetBool("isCharacterAlive" , true);
        
        if(zombiHP<0){
            zombiOlu = true;
            Destroy(GetComponent<CapsuleCollider>());
            karakterAnim.SetBool("isNearZombie" , false);

        }
        if(zombiOlu == true){
            //zombie ölma animayonu devreye girecek
                zombieAnim.SetBool("isAlive" , false);
                zombieAnim.SetBool("isMoving" , false);
                zombieAnim.SetBool("isAttack" , false);
                karakterAnim.SetBool("isNearZombie" , false);

                
        }else{
            mesafe =Vector3.Distance(this.transform.position, hedefOyuncu.transform.position);
            if(mesafe < kovalamaMesafe){
                if(zombiHP>0){
                zombieNavMesh.isStopped = false;
                zombieNavMesh.SetDestination(hedefOyuncu.transform.position);
                this.transform.LookAt(hedefOyuncu.transform.position);
                }
                

                //yürüme animasyonu çalışacak
                zombieAnim.SetBool("isMoving" , true);
                
                
            }else{
                zombieNavMesh.isStopped = true;
                // idle çalışacak;
                if(zombiHP<=0){
                //zombie ölma animayonu devreye girecek
                zombieAnim.SetBool("isAlive" , false);
                zombieAnim.SetBool("isMoving" , false);
                zombieAnim.SetBool("isAttack" , false);
                karakterAnim.SetBool("isNearZombie" , false);

                
        }else{ zombieAnim.SetBool("isMoving" , false);
                zombieAnim.SetBool("isAttack" , false);
                }
               
            }if(mesafe < saldirmaMesafesi){
                this.transform.LookAt(hedefOyuncu.transform.position);
                if(zombiHP<=0){
                //zombie ölma animayonu devreye girecek
                zombieAnim.SetBool("isAlive" , false);
                zombieAnim.SetBool("isMoving" , false);
                zombieAnim.SetBool("isAttack" , false);
                karakterAnim.SetBool("isNearZombie" , false);

                
                }else{
                zombieNavMesh.isStopped = true;
                //vurma animasyonu çalisacak
                zombieAnim.SetBool("isMoving" , false);
                zombieAnim.SetBool("isAttack" , true);
                }
                

            }
        }
    }
     public void HasarAl(){
         hedefOyuncu.GetComponent<CharacterControl>().HasarAl();
    }
    public void ZombieAttack(){
        hedefOyuncu.GetComponent<ZombieControl>().ZombiyeHasarVer();
    }
    // public float ZombieCanDondur(){
    //     float can;
    //     can = hedefOyuncu1.GetComponent<ZombieControl>.HpDondur();
    //     return can;
    // }
    
}
