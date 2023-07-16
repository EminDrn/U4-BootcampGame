using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombieControl : MonoBehaviour
{
    [SerializeField] private Rigidbody rbZombie;
    [SerializeField] private GameObject followTarget;
    [SerializeField] private Animator chAnim;
    private NavMeshAgent _agent;
    [SerializeField] private float distance;
    [SerializeField] private float followDistance;
    [SerializeField] private float attackDistance;

    public GameObject cameraObj;
    public Transform cameraTarget;

    [SerializeField] private Slider zombieSlider;
    [SerializeField] private Canvas followSlider;

    [SerializeField] private float zombieHealth;
    [SerializeField] private float zombieMaxHealth;
    [SerializeField] private Animator zombiAnim;
    [SerializeField] private bool _zombieDead = false;

    // Start is called before the first frame update
    void Start()
    {
        followTarget = GameObject.Find("AliCabbar");
        chAnim = followTarget.GetComponent<Animator>();
        cameraObj = GameObject.Find("Main Camera");
        cameraTarget = cameraObj.GetComponent<Transform>();
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        followSlider.transform.LookAt(cameraTarget);

        if (_agent.enabled == false)
        {
            return;
        }
        if (!_zombieDead)
        {
            distance = Vector3.Distance(this.transform.position, followTarget.transform.position);
            if (distance < followDistance)
            {
                _agent.transform.LookAt(followTarget.transform);
                _agent.isStopped = false;
                _agent.SetDestination(followTarget.transform.position);
                zombiAnim.SetBool("isMoving", true);
                zombiAnim.SetBool("isAttack", false);

            }
            else
            {
                _agent.isStopped = true;
                zombiAnim.SetBool("isMoving", false);
                zombiAnim.SetBool("isAttack", false);
            }
            if (distance < attackDistance)
            {
                _agent.isStopped = true;
                zombiAnim.SetBool("isMoving", false);
                zombiAnim.SetBool("isAttack", true);
            }
        }
        if (zombieHealth <= 0)
        {
            _zombieDead = true;
            zombiAnim.SetBool("isAlive", false);
        }
        if (_zombieDead)
        {
            _agent.isStopped = true;
            zombiAnim.Play("Zombie_Dying");
            chAnim.SetBool("isNearZombie", false);
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().mass = 0.01f;
            this.GetComponent<Collider>().enabled = false;
            followTarget.GetComponent<Collider>().enabled = false;

            StartCoroutine(Disappear());
        }
    }

    private void UpdateZombieHealthBar()
    {
        zombieSlider.value = zombieHealth / zombieMaxHealth;
    }

    private IEnumerator Disappear()
    {
        followTarget.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(4f);
        _agent.enabled = false; // farkl� y�ntem bulmam�z laz�m. isStopped hata al�yoruz.
        Vector3 a = transform.position;
        Vector3 b = this.transform.position;
        float t = 0.01f;
        b.y = -0.3f;
        this.gameObject.transform.position = Vector3.Lerp(a, b, t);
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
    public void ZombiyeHasarVer(){       
        zombieHealth -= Random.Range(20,25);
        UpdateZombieHealthBar();
        rbZombie.AddForce(-transform.forward * 100000);
    }

    public void ZombieGiveDamage()
    {
        followTarget.GetComponent<CharacterControl>().HasarAl();
        Debug.Log("Can Azald�");
    }

}
