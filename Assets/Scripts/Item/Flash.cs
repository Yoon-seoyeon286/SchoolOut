using UnityEngine;

public class Flash : MonoBehaviour
{
    public Light spotLight;
    public playerInventory inventory;
    public float maxRemainTime = 50.0f;

    float remainTime = 50f;

    private void Awake()
    {
        inventory = FindAnyObjectByType<playerInventory>();
    }
    void Start()
    {
        remainTime = 50f;
    }


    void Update()
    {
        if (remainTime > 0) //남아있는 시간이 있으면
        {
            spotLight.gameObject.SetActive(true);
            remainTime -= Time.deltaTime; //시간이 계속 줄어듦
            UIManager.instance.BatteryRemain(remainTime/maxRemainTime);
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
}
