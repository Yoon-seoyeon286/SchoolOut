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

    public float timeToDisappera = 2.0f;
    float exposureTime = 0f;
    bool isExposedToSpotlight = false;



    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.Damage(30f);
        }

        if (other.CompareTag("Light"))
        {
            isExposedToSpotlight = true;
            exposureTime = 0f;

        }
    }
}
