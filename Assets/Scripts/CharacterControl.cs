using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterControl : MonoBehaviour
{
    // Start is called before the first frame update
    Animator Anim;
    [SerializeField]
    private float HP =100;
    private float maxHp =100;


    bool isAlive = true;
    [SerializeField] FloatingHealthBar healthBar;

    [SerializeField] Canvas slider;
    [SerializeField] Transform cameraTarget;

    private CharacterMovement cM;
    [SerializeField] private Collider cC2;

    [SerializeField] private ZombieControl zC;
    private void Awake() {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }
    void Start()
    {
        Anim = this.GetComponent<Animator>();
        healthBar.UpdateHealthBar(HP, maxHp);
        cM = GetComponentInChildren<CharacterMovement>();
        zC = GetComponent<ZombieControl>();
    }


    // Update is called once per frame
    void Update()
    {
        slider.transform.LookAt(cameraTarget);
        if (HP<=0){
            isAlive = false;
            Anim.SetBool("isAlive", false );
        }else{
            Anim.SetBool("isAlive", true );

        }
        if(isAlive == false)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            cC2.enabled = false;
            cM.AliCabbarDeath();
            Anim.Play("Death");
        }
        
    }
    public void HasarAl(){
        HP -= Random.Range(5,10);
        healthBar.UpdateHealthBar(HP, maxHp);
        //Debug.Log("11111111111");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "zombie")
        {
            Anim.SetBool("isNearZombie", true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "zombie")
        {
            Anim.SetBool("isNearZombie", false);

        }
    }
    public void ZombieDamage()
    {
        //zC.ZombiyeHasarVer();
        Debug.Log("Zombi hasar aldý");
    }
    

}
