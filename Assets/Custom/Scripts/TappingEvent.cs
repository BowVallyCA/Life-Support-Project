using Unity.VisualScripting;
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
    }

    private void OnDisable()
    {
        _buttonManager.buttonPressed -= ButtonEventPressed;
    }

    public void ButtonEventPressed()
    {
        if (timesButtonPressed < 4)
        {
            timesButtonPressed += 1;
            Destroy(_tapIconLayout.transform.GetChild(0).gameObject);
            Debug.Log("Tapped button, need ... more");
        }
        else
        {
            timesButtonPressed = 0;
            Destroy(gameObject);
            Debug.Log("Saved yourself from having a heart attack");
        }
    }
}
