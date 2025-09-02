using UnityEngine;

public class Key : MonoBehaviour
{
    public playerInventory inventory;
    public Canvas keyCanvas;
    public AudioClip keyClip;
    AudioSource audioSource;
    EnemySpawn enemySpawn;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        enemySpawn = FindAnyObjectByType<EnemySpawn>();
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
        enemySpawn.SpawnGhostCondition();
        inventory.AddKey(gameObject);
        audioSource.PlayOneShot(keyClip);
        //gameObject.SetActive(false);
    }
}
