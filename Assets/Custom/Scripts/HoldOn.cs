using System;
using UnityEngine;

public class HoldOn : MonoBehaviour
{
    [SerializeField] private ButtonManager _buttonManager;
    [SerializeField] private AudioSource _breathAudioSource;

    private bool isStart = true;

    public event Action slowlyDying;
    public event Action holdOn;
    public event Action startGame;

    private void OnEnable()
    {
        _buttonManager.buttonPressed += ButtonEventPressed;
        _buttonManager.buttonReleased += ButtonEventReleased;
        _buttonManager.buttonHeld += ButtonEventHeld;
    }

    private void OnDisable()
    {
        _buttonManager.buttonPressed -= ButtonEventPressed;
        _buttonManager.buttonReleased -= ButtonEventReleased;
        _buttonManager.buttonHeld -= ButtonEventHeld;
    }

    public void ButtonEventHeld()
    {

    }

    public void ButtonEventPressed()
    {
        if (isStart == true)
        {
            startGame?.Invoke();
            isStart = false;
        }

        holdOn?.Invoke();
        _breathAudioSource.Play();
    }

    public void ButtonEventReleased()
    {
        slowlyDying?.Invoke();
    }
}
