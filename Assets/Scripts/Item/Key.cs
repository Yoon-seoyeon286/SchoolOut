using UnityEngine;

public class Key : MonoBehaviour
{
    public playerInventory inventory;
    public Canvas keyCanvas;
    public AudioClip keyClip;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

   public void ActiveUI()
    {
        keyCanvas.gameObject.SetActive(true);
    }

    public void FalseUI()
    {
        keyCanvas.gameObject.SetActive(false);
    }

    public void GetKey()
    {
        inventory.AddKey(gameObject);
        audioSource.PlayOneShot(keyClip);
        //gameObject.SetActive(false);
    }
}
