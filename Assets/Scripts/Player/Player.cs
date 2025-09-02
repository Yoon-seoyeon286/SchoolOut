using UnityEngine;

public class Player : MonoBehaviour
{
    float hp = 100;
    float plusHp;

    bool isDead;

    AudioSource audioSource;
    public AudioClip heartClip;
    public AudioClip deadClip;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        hp = 100;
    }

    
    void Update()
    {
        if (isDead) return;

        if (hp > 0)
        {
            hp -= Time.deltaTime;
            UIManager.instance.HpSlider(hp);
        }

        else if (hp <= 40)
        {
            audioSource.clip = heartClip;
            audioSource.Play();
        }

        else if (hp <= 0)
        {
            isDead = true;
            audioSource.PlayOneShot(deadClip);
            UIManager.instance.DeadImage();
            hp = 0f;
        }
        
    }

    public void AddHp(float addHp)
    {
        hp += addHp;

        if (hp >= 100)
        {
            hp = 100;
        }

    }

    public void Damage(float damage)
    {
        hp -= damage;
        if (hp <= 0) 
        {
            hp = 0;
        }
    }
}
