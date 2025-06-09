using System;
using UnityEngine;

public class ButtonManager : MonoBehaviour, IButtonListener
{
    [SerializeField] private AudioSource _breathAudioSource;

    private ButtonInfo _currentButton;
    private PlayerInputs inputObject;
    private bool isStart = true;

    public event Action buttonPressed;
    public event Action buttonReleased;
    public event Action buttonHeld;



    private void Awake()
    {
        _currentButton.CurrentState = ButtonState.Released;

        var inputObject = FindFirstObjectByType<PlayerInputs>();
        inputObject.RegisterListener(this);
    }

    public void ButtonHeld(ButtonInfo heldInfo)
    {
        Debug.Log("Button is being held down");
        buttonHeld.Invoke();
    }

    public void ButtonPressed(ButtonInfo pressedInfo)
    {
        Debug.Log("Button has been pressed");
        buttonPressed.Invoke();
    }

    public void ButtonReleased(ButtonInfo releasedInfo)
    {
        Debug.Log("Button has been released");
        buttonReleased.Invoke();
    }
}
