using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = FindFirstObjectByType<UIManager>();
            }

            return m_instance;
        }
    }

    static UIManager m_instance;

    public Image inventory;
   

    //���͸� ����
    public TMP_Text batteryCountUI;
    public Slider flashSlider;
    


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
    }


    public void BatteryRemain(float remainTime) //�����ִ� ���͸� ������ UI
    {
        flashSlider.value = remainTime;
    }

    public void BatteryCount(int battery) //�κ��丮 ���͸� ���� ���� ����
    {
        batteryCountUI.text = "" + battery;
    }

}
