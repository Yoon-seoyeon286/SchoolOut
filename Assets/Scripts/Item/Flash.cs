using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    public Light spotLight;
    public playerInventory inventory;

    float remainTime = 50f;

    //UI
    public Button[] buttons;

   
    void Start()
    {
        remainTime = 50f;
    }


    void Update()
    {
        if (remainTime > 0) //�����ִ� �ð��� ������
        {
            spotLight.gameObject.SetActive(true);
            remainTime -= Time.deltaTime; //�ð��� ��� �پ��
            UIManager.instance.BatteryRemain(remainTime);
        }

        else if ( remainTime <= 0)
        {
            remainTime = 0f;
            spotLight.gameObject.SetActive(false);
        }

    }



    public void BatteryTime(float batteryTime)
    {
        remainTime += batteryTime;

        if (remainTime >= 50)
        {
            remainTime = 50f;
        }

    }


    public void ActiveUI()
    {
        foreach(Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }


    public void FalseUI()
    {
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }
    }


    public void GetFlash()
    {
        inventory.AddFlash(gameObject);
        //gameObject.SetActive(false);
    }
}
