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
        if (CompareTag("Player") == true)
        {

        }
    }
}
