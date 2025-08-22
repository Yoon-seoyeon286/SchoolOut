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

    //배터리 관리
    public TMP_Text batteryCountUI;
    public Slider flashSlider;
    
    //인벤토리 열고 닫기
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


    public void BatteryRemain(float remainTime) //남아있는 배터리 게이지 UI
    {
        flashSlider.value = remainTime;
    }

    public void BatteryCount(int battery) //인벤토리 배터리 갯수 업뎃 예정
    {
        batteryCountUI.text = "" + battery;
    }

}
