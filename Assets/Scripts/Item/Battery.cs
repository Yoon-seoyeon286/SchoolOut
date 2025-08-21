using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Battery : MonoBehaviour, IItem
{
    XRGrabInteractable grab;

    public playerInventory inventory;

    //���� ����
    AudioSource batterySound;
    public AudioClip getBattery;



    private void Awake()
    {
        batterySound = GetComponent<AudioSource>();
        grab = GetComponent<XRGrabInteractable>();
    }

    public void UseItem(GameObject target)
    {
        Flash flash = target.GetComponent<Flash>();
    }

    void OnBatteryGet(SelectEnterEventArgs args)
    {
        inventory.Add(Battery);
        batterySound.PlayOneShot(getBattery);
        Destroy(gameObject);
    }
}
