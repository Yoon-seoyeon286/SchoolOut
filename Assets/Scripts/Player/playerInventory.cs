using NUnit.Framework;

using System.Collections.Generic;

using System.Security;

using UnityEditor.Rendering;

using UnityEngine;



public class playerInventory : MonoBehaviour

{

    List<GameObject> batteries = new List<GameObject>();
    List<GameObject> pills = new List<GameObject>();
    List<GameObject> keys = new List<GameObject>();
    List<GameObject> flashes = new List<GameObject>();


    int batteryCount;

    int pillCount;

    int flashCount;
    int keyCount;



    Player player;

    Flash flash;







    bool isKey;

    bool isFlash;





    private void Awake()

    {

        batteryCount = 0;

        pillCount = 0;
        flashCount = 0;
        keyCount = 0;

        flash = FindAnyObjectByType<Flash>();

        player = FindAnyObjectByType<Player>();



    }



    private void Update()

    {



    }



    public void AddBattery(GameObject battery) //배터리 넣기

    {

        batteries.Add(battery);

        batteryCount++;



        UIManager.instance.BatteryCount(batteryCount);

    }





    public void UseBattery()

    {

        if (batteryCount > 0)

        {

            GameObject batteryToUse = batteries[batteries.Count - 1];

            batteries.Remove(batteryToUse);

            batteryCount--;



            if (flash != null)

            {

                flash.BatteryTime(30f);

            }



            Destroy(batteryToUse);



            if (UIManager.instance != null)

            {

                UIManager.instance.BatteryCount(batteryCount);

            }

        }

    }



    public void AddPill(GameObject pill)

    {

        pills.Add(pill);

        pillCount++;

        UIManager.instance.PillCount(pillCount);

    }



    public void UsePill()

    {

        if (pillCount > 0)

        {

            GameObject pillToUse = pills[pills.Count - 1];

            pills.Remove(pillToUse);

            pillCount--;



            if (pillToUse != null)

            {

                player.AddHp(30f);

            }



            Destroy(pillToUse);



            if (UIManager.instance != null)

            {

                UIManager.instance.PillCount(pillCount);

            }



        }

    }



    public void AddKey(GameObject key)

    {


        key.SetActive(false);
        keyCount++;

        keys.Add(key);

        UIManager.instance.OnKey();




    }



    public void UseKey()

    {
        if (keyCount > 0)

        {

            GameObject keyToUse = keys[keys.Count - 1];

            keys.Remove(keyToUse);

            keyCount--;



            if (keyToUse != null)

            {

                keyToUse.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
                keyToUse.SetActive(true);

            }


            if (UIManager.instance != null)

            {

                UIManager.instance.OffKey();

            }



        }
    }







    public void AddFlash(GameObject flash)

    {
        flash.SetActive(false);

        flashes.Add(flash);
        flashCount++;

        UIManager.instance.OnFlash();



    }




    public void UseFlash()

    {

        if (flashCount > 0)

        {

            GameObject flashToUse = flashes[flashes.Count - 1];

            flashes.Remove(flashToUse);

            flashCount--;



            if (flashToUse != null)

            {

                flashToUse.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
                flashToUse.SetActive(true);

            }


            if (UIManager.instance != null)

            {

                UIManager.instance.OffFlash();

            }



        }
    }
}
    

