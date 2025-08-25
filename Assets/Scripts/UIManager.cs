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
    


    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
        }
      
    }


    //인벤토리 열고 닫기
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


    public void BatteryRemain(float remainTime) //남아있는 배터리 게이지 UI
    {
        flashSlider.value = remainTime;
    }

    public void BatteryCount(int battery) //인벤토리 배터리 갯수 업뎃 예정
    {
        batteryCountUI.text = "" + battery;
    }

}
