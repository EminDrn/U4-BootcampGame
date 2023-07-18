using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float chaseSpeed = 5;
    void Start()
    {
        if (!target)
        {
            target = GameObject.FindObjectOfType<CharacterMovement>().transform;
        }
    }

    private void LateUpdate()
    {
        transform.position=Vector3.Lerp(transform.position,target.position+offset,chaseSpeed*Time.deltaTime);
        Vector3 newRotation = new Vector3(50,0,0);
        transform.eulerAngles = newRotation;
    }
}
