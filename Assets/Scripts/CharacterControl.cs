using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    // Start is called before the first frame update
    Animator Anim;
    [SerializeField]
    private float HP =100;
    private float maxHp =100;


    bool isAlive;
    [SerializeField] FloatingHealthBar healthBar;
    private void Awake() {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }
    void Start()
    {
        Anim = this.GetComponent<Animator>();
        healthBar.UpdateHealthBar(HP, maxHp);
        


    }


    // Update is called once per frame
    void Update()
    {
        if(HP<=0){
            isAlive = false;
            Anim.SetBool("isAlive", false );
        }else{
            Anim.SetBool("isAlive", true );

        }
        if(isAlive == false){
            //oyun bitecek
        }
        
    }
    public void HasarAl(){
        HP -= Random.Range(5,10);
        healthBar.UpdateHealthBar(HP, maxHp);
        Debug.Log("11111111111");
    }
    
    
    

}
