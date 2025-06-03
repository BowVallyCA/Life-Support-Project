using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HoldOn _holdOn;
    [SerializeField] private Image _fadeImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        _holdOn.slowlyDying += FadingOut;
    }

    private void OnDisable()
    {
        _holdOn.slowlyDying -= FadingOut;
    }

    private void FadingOut()
    {
        _fadeImage.
    }
}
