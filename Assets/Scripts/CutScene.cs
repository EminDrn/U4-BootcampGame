using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject bC;
    [SerializeField] private GameObject aliCabbar;

    [SerializeField] private Transform yenidenDogTransform;

    private void Start()
    {
    }
    private void Update()
    {
    }
    public void CanvasTrue()
    {
        canvas.SetActive(true);
    }
    public void CanvasFalse()
    {
        canvas.SetActive(false);
    }

    public void BossSpeedCS()
    {
        bC = GameObject.Find("Boss_Roaring Variant(Clone)");
        bC.GetComponent<BossControl>();
        bC.GetComponent<BossControl>().BossSpeed();
        aliCabbar.transform.position = new Vector3(-3.82f, yenidenDogTransform.position.y, -100f);
    }
    public void BossSpeedNormalCS()
    {
        bC = GameObject.Find("Boss_Roaring Variant(Clone)");
        bC.GetComponent<BossControl>();
        bC.GetComponent<BossControl>().BossSpeedNormal();
        aliCabbar.transform.position = new Vector3(yenidenDogTransform.position.x, yenidenDogTransform.position.y, yenidenDogTransform.position.z);
    }

    public void AliCabbarYukari()
    {
    }

    public void AliCabbarAsagi()
    {
    }
}
