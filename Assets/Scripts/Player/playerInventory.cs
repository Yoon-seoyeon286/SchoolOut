using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    List<GameObject> items = new List<GameObject>();
    int batteryCount;

    Flash flash;

    private void Awake()
    {
        batteryCount = 0;
        flash = FindAnyObjectByType<Flash>();
    }

    private void Update()
    {
        
    }

    public void AddBattery(GameObject battery) //배터리 넣기
    {
        items.Add(battery);
        batteryCount++;

        UIManager.instance.BatteryCount(batteryCount);
    }

    
    public void UseBattery()
    {
        if (batteryCount > 0)
        {
            GameObject batteryToUse = items[items.Count - 1];
            items.Remove(batteryToUse);
            batteryCount--;

            if(flash!= null)
            {
                flash.BatteryTime(30f);
            }

            Destroy(batteryToUse);

            if(UIManager.instance!= null)
            {
                UIManager.instance.BatteryCount(batteryCount);
            }
        }
    }
}
