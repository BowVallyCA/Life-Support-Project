using System;
using UnityEngine;

public class TappingEvent : MonoBehaviour
{
    private ButtonManager _buttonManager;
    private GameObject _tapIconLayout;
    private FadingControl _fadeControl;

    private int timesButtonPressed = 0;
    private float timeTillDeath = 10f;



    private void Awake()
    {
        _buttonManager = FindFirstObjectByType<ButtonManager>();
        _tapIconLayout = GameObject.Find("TapIconLayout");
        _fadeControl = FindFirstObjectByType<FadingControl>();

        HoldOn holdOn = FindFirstObjectByType<HoldOn>();
        holdOn.enabled = false;
        holdOn.ButtonEventReleased();
    }

    private void Update()
    {
        if (timeTillDeath > 0)
        {
            timeTillDeath -= Time.deltaTime;
        }
        else
        {
            _fadeControl.GameOver();
            Debug.Log("You Died");
        }
    }

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
        //I dont need this fuction in the script however if I dont have it I get errors.
    }

    public void ButtonEventPressed()
    {
        if (timesButtonPressed < 4)
        {
            timesButtonPressed += 1;
            Destroy(_tapIconLayout.transform.GetChild(0).gameObject);
        }
        else
        {
            timesButtonPressed = 0;
            Destroy(gameObject);
        }
    }

    public void ButtonEventReleased()
    {
        //I dont need this fuction in the script however if I dont have it I get errors.
    }

    private void OnDestroy()
    {
        GameEventsManager eventTimer = FindFirstObjectByType<GameEventsManager>();
        eventTimer.StartTimer();

        HoldOn holdOn = FindFirstObjectByType<HoldOn>();
        holdOn.enabled = true;
    }
}
