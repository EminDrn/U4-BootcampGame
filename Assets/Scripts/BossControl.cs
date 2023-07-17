using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossControl : MonoBehaviour
{
    [SerializeField] private Rigidbody rbBossZombie;
    [SerializeField] private GameObject followTarget;
    [SerializeField] private Animator chAnim;
    private NavMeshAgent _bossAgent;
    [SerializeField] private float distance;
    [SerializeField] private float followDistance;
    [SerializeField] private float attackDistance;

    //public GameObject cameraObj;
    //public Transform cameraTarget;

    [SerializeField] private Slider bossSlider;
    //[SerializeField] private Canvas followSlider;

    [SerializeField] private float zombieHealth;
    [SerializeField] private float zombieMaxHealth;
    [SerializeField] private Animator zombiAnim;
    [SerializeField] private bool _zombieDead = false;
    [SerializeField] private bool addZF = false;

    [SerializeField] private GameObject eventSysObj;
    [SerializeField] private DayNightCycle eventSysZC;

    // Start is called before the first frame update
    void Start()
    {
        followTarget = GameObject.Find("AliCabbar");
        chAnim = followTarget.GetComponent<Animator>();

        //cameraObj = GameObject.Find("Main Camera");
        //cameraTarget = cameraObj.GetComponent<Transform>();

        _bossAgent = GetComponent<NavMeshAgent>();

        eventSysObj = GameObject.Find("EventSystem");
        eventSysZC = eventSysObj.GetComponent<DayNightCycle>();

    }

    // Update is called once per frame
    void Update()
    {
        //followSlider.transform.LookAt(cameraTarget);

        if (_bossAgent.enabled == false)
        {
            return;
        }
        if (!_zombieDead)
        {
            distance = Vector3.Distance(this.transform.position, followTarget.transform.position);
            if (distance < followDistance)
            {
                _bossAgent.transform.LookAt(followTarget.transform);
                _bossAgent.isStopped = false;
                _bossAgent.SetDestination(followTarget.transform.position);
                zombiAnim.SetBool("isMoving", true);
                zombiAnim.SetBool("isAttack", false);

            }
            else
            {
                _bossAgent.isStopped = true;
                zombiAnim.SetBool("isMoving", false);
                zombiAnim.SetBool("isAttack", false);
            }
            if (distance < attackDistance)
            {
                _bossAgent.isStopped = true;
                zombiAnim.SetBool("isMoving", false);
                zombiAnim.SetBool("isAttack", true);
            }
        }
        if (zombieHealth <= 0)
        {
            addZF = false;
            _zombieDead = true;
            zombiAnim.SetBool("isAlive", false);
            zombiAnim.Play("Boss_Death");
        }
        if (_zombieDead)
        {
            _bossAgent.isStopped = true;
            zombiAnim.Play("Zombie_Dying");
            chAnim.SetBool("isNearZombie", false);
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().mass = 0.01f;
            this.GetComponent<Collider>().enabled = false;
            followTarget.GetComponent<Collider>().enabled = false;

            StartCoroutine(Disappear());
        }

        if (addZF)
        {
            rbBossZombie.AddForce(Vector3.forward * 100);
        }
    }

    private void UpdateZombieHealthBar()
    {
        bossSlider.value = zombieHealth / zombieMaxHealth;
    }
    public void BossTakeDamage()
    {

        addZF = true;
        zombieHealth -= Random.Range(20, 25);
        UpdateZombieHealthBar();
        rbBossZombie.AddForce(-transform.forward * 1);
        StartCoroutine(AddForceZombie());
        //-transform.forward * 100000
    }

    private IEnumerator Disappear()
    {
        followTarget.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(4f);
        _bossAgent.enabled = false; // farklý yöntem bulmamýz lazým. isStopped hata alýyoruz.
        Vector3 a = transform.position;
        Vector3 b = this.transform.position;
        float t = 0.01f;
        b.y = -1f;
        this.gameObject.transform.position = Vector3.Lerp(a, b, t);
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
        eventSysZC.ZombieCountLess(); // zombie count floatý -1 azalýr
    }

    public void ZombieGiveDamage()
    {
        followTarget.GetComponent<CharacterControl>().BossGiveDamage();
        Debug.Log("Can Azaldý");
    }

    private IEnumerator AddForceZombie()
    {
        yield return new WaitForSeconds(0.1f);
        addZF = false;
    }
}
