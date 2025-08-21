using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

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

    //���͸� ����
    public Text batteryCountUI;



    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
    }


    public void BatteryRemain(float remainTime)
    {

    }

    public void BatteryCount(int battery)
    {

        batteryCountUI.text = "���� : " + battery;
    }

}
