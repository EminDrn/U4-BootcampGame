using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeDamage : MonoBehaviour
{
    [SerializeField] LayerMask layermask;
    private void Update()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 20f, layermask))
        {
            Debug.Log("KalbimeGeldi");
            Debug.DrawLine(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);
        }else
        {
            Debug.Log("Kalbime Gelmedi");
            Debug.DrawLine(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.green);
        }
    }
}
