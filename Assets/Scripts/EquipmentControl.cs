using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentControl : MonoBehaviour
{
    public GameObject axe;
    public GameObject shovel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tree"))
        {
            axe.SetActive(true);
            shovel.SetActive(false);
        }
        else if (other.CompareTag("stone"))
        {
            shovel.SetActive(true);
            axe.SetActive(false);

        }else if (other.CompareTag("car"))
        {
            shovel.SetActive(true);
            axe.SetActive(false);

        }else{
            shovel.SetActive(false);
            axe.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other) {
        shovel.SetActive(false);
        axe.SetActive(false);
    }
}
