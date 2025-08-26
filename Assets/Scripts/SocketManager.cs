using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SocketManager : MonoBehaviour
{
    public XRSocketInteractor vaseSocket;
    public XRSocketInteractor paintSocket;
    public XRSocketInteractor ballSocket;
    public XRSocketInteractor bookSocket;

    int correctitemCount = 0;

    AudioSource passwordSound;
    public AudioClip audioClip;

    private void Awake()
    {
        passwordSound = GetComponent<AudioSource>();
    }

    void Start()
    {
        vaseSocket.selectEntered.AddListener(OnItemPlaced);
        paintSocket.selectEntered.AddListener(OnItemPlaced);
        ballSocket.selectEntered.AddListener(OnItemPlaced);
        bookSocket.selectEntered.AddListener(OnItemPlaced);

    }

    void OnItemPlaced(SelectEnterEventArgs args)
    {
        //놓여있는 아이템 태그 확인용
        string itemTag = args.interactableObject.transform.gameObject.tag;

        if (itemTag == "vase" || itemTag == "paint" || itemTag == "ball" || itemTag == "book")
        {
            correctitemCount++;

            if (correctitemCount == 4)
            {
                PasswordSound();
            }
        }
    }

    void PasswordSound()
    {
        passwordSound.PlayOneShot(audioClip);
    }

}
