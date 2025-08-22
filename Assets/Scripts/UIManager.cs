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

    //배터리 관리
    public Text batteryCountUI;
    public Slider flashSlider;
    



    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
    }


    public void BatteryRemain(float remainTime) //남아있는 배터리 게이지 UI
    {
        flashSlider.value = remainTime / 50.0f;
    }

    public void BatteryCount(int battery) //인벤토리 배터리 갯수 업뎃 예정
    {
        batteryCountUI.text = "개수 : " + battery;
    }

}
