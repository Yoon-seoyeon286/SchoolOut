using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    List<GameObject> items = new List<GameObject>();
    int batteryCount = 0;

    public void AddBattery(GameObject battery)
    {
        if(!items.Contains(battery))
        {
            items.Add(battery);
            batteryCount++;

            UIManager.instance.BatteryCount(batteryCount);
        }
    }
    
    public bool HasBattery(GameObject battery)
    {
        return items.Contains(battery);
    }
}
