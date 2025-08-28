using UnityEngine;

public class Key : MonoBehaviour
{
    public playerInventory inventory;

    public AudioClip keyClip;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void GetKey()
    {
        inventory.AddKey(gameObject);
        audioSource.PlayOneShot(keyClip);
        gameObject.SetActive(false);
    }
}
