using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    List<GameObject> items = new List<GameObject>();
    int batteryCount = 0;

    public void AddBattery(GameObject battery) //���͸� �߰�
    {
        items.Add(battery);
        batteryCount++;

        UIManager.instance.BatteryCount(batteryCount);
    }

    public void UseBattery(GameObject battery) //���͸� ���
    {
        items.Remove(battery);
        batteryCount--;
        UIManager.instance.BatteryCount(batteryCount);
    }
    
}
