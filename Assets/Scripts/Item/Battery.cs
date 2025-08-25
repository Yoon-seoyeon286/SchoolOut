using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Battery : MonoBehaviour, IItem
{
    XRGrabInteractable grab;

    public playerInventory inventory;

    //배터리 관리
    AudioSource batterySound;
    public AudioClip getBattery;



    private void Awake()
    {
        batterySound = GetComponent<AudioSource>();
        grab = GetComponent<XRGrabInteractable>();

        grab.selectEntered.AddListener(OnBatteryGet);
    }

    public void UseItem(GameObject target)
    {
        Flash flash = target.GetComponent<Flash>();
        flash.BatteryTime(30f); //손전등에 30초 전달
        inventory.UseBattery(gameObject);
    }

    public void OnBatteryGet(SelectEnterEventArgs args) 
    { 
        inventory.AddBattery(gameObject); //인벤토리에 해당 아이템을 넣음
        batterySound.PlayOneShot(getBattery); //소리

        gameObject.SetActive(false);
    }
}
