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

        grab.selectEntered.AddListener(OnBatteryGet);
    }

    public void UseItem(GameObject target)
    {
        Flash flash = target.GetComponent<Flash>(); //Ÿ�� ������
        flash.BatteryTime(30f); //����� 30�� ����
        inventory.UseBattery(gameObject);
    }

    public void OnBatteryGet(SelectEnterEventArgs args) //�������� ����� �� �Ͼ�� ��
    { 
        inventory.AddBattery(gameObject); //�κ��丮�� ������Ʈ�� �߰�
        batterySound.PlayOneShot(getBattery); //�Ҹ� ���

        gameObject.SetActive(false);
    }
}
