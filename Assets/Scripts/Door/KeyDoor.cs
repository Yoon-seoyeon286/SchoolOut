using System.Xml.Serialization;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public GameObject key;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void KeyEntered()
    {
        animator.SetBool("IsKey", true);
        key.gameObject.SetActive(false);
    }
}
