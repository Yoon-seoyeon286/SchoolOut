using System.Collections;
using System.Security;
using System.Xml;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    public Light spotLight;

    AudioSource audioSource;
    public AudioClip defaultClip;
    public AudioClip attackClip;
    public AudioClip deadClip;

    public float timeToDisappera = 2.0f;
    float exposureTime = 0f;
    bool isExposedToSpotlight = false;
    bool isDead = false;



    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        audioSource.clip = defaultClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            agent.SetDestination(target.position);
       
        }
        else
        {
            agent.isStopped = true;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.Damage(30f);
            audioSource.PlayOneShot(attackClip);
            UIManager.instance.DamageUI();

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Light"))
        {
            exposureTime += Time.deltaTime;
            if (exposureTime >= timeToDisappera)
            {
                isDead = true;
                StartCoroutine(DeadEnemy());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Light"))
        {
            exposureTime = 0f;
        }
    }



    IEnumerator DeadEnemy()
    {
        audioSource.PlayOneShot(deadClip);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        
    }
}
