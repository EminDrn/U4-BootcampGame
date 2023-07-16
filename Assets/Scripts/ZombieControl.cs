using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieControl : MonoBehaviour
{
//    // Start is called before the first frame update
    Animator Anim;
    [SerializeField]
    public static float HP =100;
    private float maxHp =100;
    bool isAlive = true;
    [SerializeField] FloatingHealthBar healthBar;
    public GameObject Zombie;
    
    [SerializeField] Canvas sliderZombie;
    [SerializeField] Transform cameraTarget;

    // private void Awake() {
    //     healthBar = GetComponentInChildren<FloatingHealthBar>();
    // }
    void Start()
    {
        
        Zombie = GameObject.Find("Zombie Transition (1)");
    
        //Anim = Zombie.GetComponent<Animator>();
        healthBar.UpdateHealthBar(HP, maxHp);

    }


    // Update is called once per frame
    void Update()
    {
        sliderZombie.transform.LookAt(cameraTarget);
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("zombie");
        foreach(var zombi in zombies ){
        Anim = zombi.GetComponent<Animator>();
        Debug.Log(zombi.name + "  " + HP+ " ---");
        if(HP<=0){
            isAlive = false;
            Anim.SetBool("isAlive", false );
        }else{
            Anim.SetBool("isAlive", true );

        }
            if(isAlive == false)
            {
                Anim.Play("death");
            }
        }
        
    }
    public void ZombiyeHasarVer(){       
        HP -= Random.Range(20,25);
        healthBar.UpdateHealthBar(HP, maxHp);
        Debug.Log("22222222");
        HpDondur();

    }
    public float HpDondur(){
        float can = HP;
        return HP;
    }
   
}
