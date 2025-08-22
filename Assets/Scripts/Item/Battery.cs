using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Battery : MonoBehaviour, IItem
{
    XRGrabInteractable grab;

    public playerInventory inventory;

    //사운드 관리
    AudioSource batterySound;
    public AudioClip getBattery;



    private void Awake()
    {
        batterySound = GetComponent<AudioSource>();
        grab = GetComponent<XRGrabInteractable>();
    }

    void Update()
    {
        grab.selectEntered.AddListener(OnBatteryGet); //함수 호출
    }

    public void UseItem(GameObject target) 
    {
        Flash flash = target.GetComponent<Flash>(); //타겟 손전등
        flash.BatteryTime(30f); //손전등에 30초 전달
        inventory.UseBattery(gameObject);
    }

    void OnBatteryGet(SelectEnterEventArgs args) //아이템을 쥐었을 때 일어나는 일
    {
        inventory.AddBattery(gameObject); //인벤토리에 오브젝트를 추가
        
        batterySound.PlayOneShot(getBattery); //소리 재생
        Destroy(gameObject); // 파괴
    }
}
