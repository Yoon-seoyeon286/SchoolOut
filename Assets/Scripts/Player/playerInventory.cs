using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    List<GameObject> items = new List<GameObject>();
    int batteryCount;

    Flash flash;

    bool isKey;

    private void Awake()
    {
        batteryCount = 0;
        flash = FindAnyObjectByType<Flash>();
        isKey = false;
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

    public void AddKey(GameObject key)
    {
        if (isKey == false)
        {
            items.Add(key);
            UIManager.instance.OnKey();
            isKey = true;
        }

        else return;
    }

    public void UseKey()
    {
        if (isKey == true)
        {
            GameObject keyUseThat = items[items.Count - 1];
            items.Remove(keyUseThat);
            UIManager.instance.OffKey();

            Instantiate(keyUseThat, transform.position, Quaternion.identity);
        }
    }
}
