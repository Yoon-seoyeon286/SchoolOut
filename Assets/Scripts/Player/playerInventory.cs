using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    List<GameObject> items = new List<GameObject>();
    int batteryCount = 0;

    private void Update()
    {
        
    }

    public void AddBattery(GameObject battery) //배터리 넣기
    {
        items.Add(battery);
        batteryCount++;

        UIManager.instance.BatteryCount(batteryCount);
    }

    public void UseBattery(GameObject battery) //배터리 사용
    {
        items.Remove(battery);
        batteryCount--;

        Battery battery1 = battery.GetComponent<Battery>();

        Flash flash = FindAnyObjectByType<Flash>();
        
        battery1.UseItem(flash.gameObject);

        UIManager.instance.BatteryCount(batteryCount);
    }
    
}
