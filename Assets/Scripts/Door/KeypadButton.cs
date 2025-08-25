using UnityEngine;

public class KeypadButton : MonoBehaviour
{
    public KeypadManager keypad;
    public string buttonValue;

    public void OnPressButton()
    {
        if (buttonValue == "Enter")
        {
            keypad.CheckCode();
        }

        else
        {
            keypad.AddDigit(buttonValue);
        }
    }
}
