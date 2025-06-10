using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private ButtonManager _buttonManager;

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
        SceneManager.LoadScene("ActualGame");
    }

    public void ButtonEventReleased()
    {

    }
}
