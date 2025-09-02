using UnityEngine;

public class Player : MonoBehaviour
{
    float hp = 100;
    float plusHp;

    bool isDead;

    AudioSource audioSource;
    public AudioClip heartClip;
    public AudioClip deadClip;
    bool isLowHpSoundPlaying = false;

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
        }

        UIManager.instance.HpSlider(hp);

        if (hp <= 50&&hp>0)
        {
            if (!isLowHpSoundPlaying) // 사운드가 재생 중이 아닐 때만
            {
                audioSource.clip = heartClip;
                audioSource.loop = true;
                audioSource.Play(); // PlayOneShot 대신 Play 사용
                isLowHpSoundPlaying = true;
            }
        }
        else
        {
            if (isLowHpSoundPlaying)
            {
                audioSource.Stop();
                audioSource.loop = false;
                isLowHpSoundPlaying = false;
            }
        }

        if (hp <= 0)
        {
            isDead = true;
            audioSource.PlayOneShot(deadClip);
            UIManager.instance.DeadImage();
  
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
