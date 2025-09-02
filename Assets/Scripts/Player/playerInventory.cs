using NUnit.Framework;
using System.Collections.Generic;
using System.Security;
using UnityEditor.Rendering;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    List<GameObject> items = new List<GameObject>();
    int batteryCount;
    int pillCount;

    Player player;
    Flash flash;

    GameObject flashOriginal;
    GameObject keyOriginal;

    bool isKey;
    bool isFlash;


    private void Awake()
    {
        batteryCount = 0;
        pillCount = 0;
        flash = FindAnyObjectByType<Flash>();
        player = FindAnyObjectByType<Player>();
        isKey = false;
        isFlash = false;
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

    public void AddPill(GameObject pill)
    {
        items.Add(pill);
        pillCount++;
        UIManager.instance.PillCount(pillCount);
    }

    public void UsePill()
    {
        if (pillCount > 0)
        {
            GameObject pillToUse = items[items.Count - 1];
            items.Remove(pillToUse);
            pillCount--;

            if (pillToUse != null)
            {
                player.AddHp(30f);
            }

            Destroy(pillToUse);

            if(UIManager.instance.)

        }
    }

    public void AddKey(GameObject key)
    {
        if (!isKey)
        {
            keyOriginal = key;
            keyOriginal.SetActive(false);
            items.Add(keyOriginal);
            UIManager.instance.OnKey();
            isKey = true;
        }
    }

    public void UseKey()
    {
        if (isKey)
        {
            GameObject keyToUse = items.Find(item => item.GetComponent<Key>() != null);

            if (keyToUse != null)
            {
                items.Remove(keyToUse);
                UIManager.instance.OffKey();
                keyOriginal.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
                keyOriginal.SetActive(true);

                isKey = false;
            }
        }
    }

    public void AddFlash(GameObject flash)
    {
        if (!isFlash)
        {
        flashOriginal = flash;
            flashOriginal.SetActive(false);

        items.Add(flashOriginal);
        UIManager.instance.OnFlash();
        isFlash = true;
        }
    }

    public void UseFlash()
    {
        if (isFlash)
        {
            GameObject flashToUse = items.Find(item => item.GetComponent<Flash>() != null);
            {
                if (flashToUse != null) { 
                    items.Remove(flashToUse);
                UIManager.instance.OffFlash();

                flashOriginal.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
                flashOriginal.SetActive(true);
                  

                isFlash = false;
                }
            }
        }

        else
        {
            Debug.Log("소환불가");
        }

    }
}
