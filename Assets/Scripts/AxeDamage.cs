using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeDamage : MonoBehaviour
{
    [SerializeField] LayerMask layermask;

    private Touch touch;

    [SerializeField] private Animator chAnim;
    [SerializeField] private Animator takeDamageAnim;

    private void Start()
    {
    }

    private void Update()
    {
        //distance = cE.ZombieDistance();
    }

    private void OnDrawGizmos()
    {
        float maxDistance = 2.5f;
        RaycastHit hit;

        bool isHit = Physics.BoxCast(transform.position, transform.lossyScale / 2, transform.forward, out hit, transform.rotation, maxDistance, layermask);

        if(isHit)
        {
            chAnim.SetBool("isNearZombie", true);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, transform.lossyScale);
        }
        else
        {
            chAnim.SetBool("isNearZombie", false);
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
        }

    }
}
