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
    
    //�κ��丮 ���� �ݱ�
    public void OnInventory()
    {
        inventory.gameObject.SetActive(true);

    }



    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
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
