using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] public float movementSpeed;
    [SerializeField] public float rotationSpeed = 500;
    private Touch _touch;
    private Vector3 _touchUp;
    private Vector3 _touchDown;
    private bool _dragStarted;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
         animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.touchCount >0){
            _touch =Input.GetTouch(0);
            if(_touch.phase == TouchPhase.Began){
                _dragStarted =true;    
                _touchDown = _touch.position;
                _touchUp = _touch.position;
                animator.SetBool("isMoving", true);
            }
        }
        if(_dragStarted == true){
            if(_touch.phase == TouchPhase.Moved){
                _touchDown = _touch.position;
            }
            if(_touch.phase == TouchPhase.Ended){
                _touchDown = _touch.position;
                animator.SetBool("isMoving", false);
                
                _dragStarted =false;
                
            }
            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation , CalculateRotation() , rotationSpeed * Time.deltaTime);
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime*movementSpeed);
        }
    }
    Quaternion CalculateRotation(){
        Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);
        return temp;
    }
    Vector3 CalculateDirection(){
        Vector3 temp = (_touchDown -_touchUp).normalized;
        temp.z = temp.y;
        temp.y = 0;
        return temp;
    }

    public void AliCabbarDeath()
    {
        movementSpeed = 0;
        rotationSpeed = 0;
    }
}
