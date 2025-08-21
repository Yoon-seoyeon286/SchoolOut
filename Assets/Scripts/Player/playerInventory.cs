using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    List<GameObject> items = new List<GameObject>();

    public void AddBattery(GameObject battery)
    {
        if(!items.Contains(battery))
        {
            items.Add(battery);
        }
    }
}
