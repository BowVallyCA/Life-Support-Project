using System;
using UnityEngine;

public class HoldOn : MonoBehaviour, IButtonListener
{
    private ButtonInfo _currentButton;
    private PlayerInputs inputObject;

    public event Action slowlyDying;

    private void Awake()
    {
        _currentButton.CurrentState = ButtonState.Released;

        var inputObject = FindFirstObjectByType<PlayerInputs>();
        inputObject.RegisterListener(this);
    }

    public void ButtonHeld(ButtonInfo heldInfo)
    {
        Debug.Log("Button is being held down");
    }

    public void ButtonPressed(ButtonInfo pressedInfo)
    {

    }

    public void ButtonReleased(ButtonInfo releasedInfo)
    {
        Debug.Log("Button has been released");
        slowlyDying?.Invoke();
    }
}
