using UnityEngine;

public class Flash : MonoBehaviour, IItem
{
    public Light spotLight;

    float remainTime = 50f;

    void Start()
    {
        remainTime = 50f;
    }


    void Update()
    {
        if (remainTime > 0)
        {
            remainTime -= Time.deltaTime;
            UIManager.instance.BatteryRemain(remainTime);
        }

    }

    public void UseItem(GameObject target)
    {
        playerInventory playerInventory = target.GetComponent<playerInventory>();

        if (playerInventory.HasBattery ==true && remainTime <= 50f )
        {
            spotLight.gameObject.SetActive(true);
        }

        else if(battery == null || remainTime <= 0)
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
}
