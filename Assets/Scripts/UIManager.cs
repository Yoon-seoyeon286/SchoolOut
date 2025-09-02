using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindFirstObjectByType<UIManager>();
            }

            return m_instance;
        }
    }

    static UIManager m_instance;

    public Image inventory;
    public playerInventory playerinventory;


    //���͸� ����
    public TMP_Text batteryCountUI;
    public Slider flashSlider;

    //pill
    public TMP_Text pillCountUI;


    //���� ����
    public RawImage keyImage;

    //������ ����
    public RawImage flashImage;

    //HP ����
    public Slider hpSlider;

    //damdage
    public RawImage damageImage;
    float fadeDuration = 2f;

    //dead
    public RawImage deadImage;


    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
        }


    }


    //�κ��丮 ���� �ݱ�
    public void OnInventory()
    {

        inventory.gameObject.SetActive(true);


    }

    public void OffInvnetory()
    {

        inventory.gameObject.SetActive(false);

    }

    private void Update()
    {
        flashSlider.minValue = 0f;
        flashSlider.maxValue = 50f;


        hpSlider.minValue = 0f;
        hpSlider.maxValue = 100f;
    }


    public void BatteryRemain(float remainTime) //�����ִ� ���͸� ������ UI
    {
        flashSlider.value = remainTime;
    }

    public void BatteryCount(int battery) //�κ��丮 ���͸� ���� ���� ����
    {
        batteryCountUI.text = "" + battery;
    }

    public void PillCount(int pill)
    {
        pillCountUI.text = "" + pill;
    }

    public void OnKey()
    {
        keyImage.gameObject.SetActive(true);
    }

    public void OffKey()
    {
        playerinventory.UseKey();
        keyImage.gameObject.SetActive(false);
    }

    public void OnFlash()
    {
        flashImage.gameObject.SetActive(true);
    }

    public void OffFlash()
    {
        playerinventory.UseFlash();
        flashImage.gameObject.SetActive(false);
    }

    public void HpSlider(float hpGaze)
    {
        hpSlider.value = hpGaze;
    }


    public void DamageUI()
    {
        damageImage.gameObject.SetActive(true);
        StartCoroutine(FadeOutImage());


    }

    IEnumerator FadeOutImage()
    {
        Color startColor = damageImage.color;
        float t = 0;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            damageImage.color = new Color(startColor.r, startColor.g, startColor.b);
            yield return null;

        }

        damageImage.color = new Color(startColor.r, startColor.g, startColor.b);
        damageImage.gameObject.SetActive(false);
    }

    public void DeadImage()
    {
        deadImage.gameObject.SetActive(true);
    }

    public void ReGame()
    {
        SceneManager.LoadScene("schoolMain");
    }

    public void GiveUP()
    {
        Application.Quit();
    }
}
