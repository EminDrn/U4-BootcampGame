using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class CharacterControl : MonoBehaviour
{
    // Start is called before the first frame update
    Animator Anim;
    [SerializeField]
    private float HP =100;
    private float maxHp =100;

    private bool hpAdded = true;


    bool isAlive = true;
    [SerializeField] FloatingHealthBar healthBar;

    [SerializeField] Canvas slider;
    [SerializeField] Transform cameraTarget;

    private CharacterMovement cM;
    [SerializeField] private Collider cC2;

    [SerializeField] private ZombieControl zC;

    [SerializeField] private Animator damageAnimator;

    [SerializeField] private Collider takeDamage;
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

        if (HP < 100 && hpAdded)
        {
            hpAdded = false;
            Invoke("AddHealth", 10f);
        } else if (HP > 100){
            HP = 100;
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
    public void ZombieDamageCol()
    {
        takeDamage.enabled = true;
    }

    public void ZombieDamageColDeAc()
    {
        takeDamage.enabled = false;
    }

    private void AddHealth ()
    {
        HP += 50f;
        healthBar.UpdateHealthBar(HP, maxHp);
        Debug.Log("Can eklendi");
        hpAdded = true;
    }

}
