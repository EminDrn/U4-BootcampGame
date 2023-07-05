using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTree : MonoBehaviour
{
     public GameObject[] agacBolumleri;

    private int indeks;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("çakışma meydana geldi");
        if (other.CompareTag("tree"))
        {
            StartCoroutine(YokEtmeRoutine());
        }
    }

    private IEnumerator YokEtmeRoutine()
    {
        while (indeks < agacBolumleri.Length)
        {
            yield return null; // Bir sonraki frame'i beklemek için null döndürülür.

            if (agacBolumleri[indeks] != null)
            {
                Destroy(agacBolumleri[indeks]);
            }

            indeks++;
        }
    }
}
