using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private Animator m_Animator;
    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "zombie")
        {
            other.GetComponent<ZombieControl>().ZombiyeHasarVer();
        }

        if (other.tag == "Boss")
        {
            other.GetComponent<BossControl>().BossTakeDamage();
        }
    }
}
