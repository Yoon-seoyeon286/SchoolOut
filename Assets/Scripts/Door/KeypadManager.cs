using UnityEngine;
using TMPro;

public class KeypadManager : MonoBehaviour
{
    public TMP_Text passwordScreen;
    public string correctCode = "76800";
    public Animator doorAnimator;
    public float openTime = 5.0f;

    string currentInput = "";
    bool isOpen = false;

    public void RefreshScreen()
    {
        passwordScreen.text = currentInput;
    }

    public void AddDigit(string digit)
    {
        if (currentInput.Length < correctCode.Length)
        {
            currentInput += digit;
            RefreshScreen();
        }
    }

    void ClearInput()
    {
        currentInput = "";
        RefreshScreen();

    }

    public void CheckCode()
    {
        if (currentInput == correctCode)
        {
            OpenDoor();
            ClearInput();
        }

        else
        {
            ClearInput();
        }
    }

    public void OpenDoor()
    {
        if (!isOpen)
        {
            doorAnimator.SetBool("IsOpen", true);
            isOpen = true;
            Invoke("CloseDoor", openTime);
        }
    }

    public void CloseDoor()
    {
        if (isOpen)
        {
            doorAnimator.SetBool("IsOpen", false);
            isOpen = false;
        }
    }

}
