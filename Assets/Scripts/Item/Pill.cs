using UnityEngine;

public class Pill : MonoBehaviour
{
    public playerInventory inventory;

    AudioSource audioSource;
    public AudioClip getPillClip;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetPill()
    {
        inventory.AddPill(gameObject);
        gameObject.SetActive(false);
        audioSource.PlayOneShot(getPillClip);
    }
    

}
