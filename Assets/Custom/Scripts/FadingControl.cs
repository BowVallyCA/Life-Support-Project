using UnityEngine;

public class FadingControl : MonoBehaviour
{
    [SerializeField] private HoldOn _holdOn;
    [SerializeField] private Animator _fadeInAnim;
    [SerializeField] private GameObject _deathScreen;

    private void OnEnable()
    {
        _holdOn.slowlyDying += FadingIn;
        _holdOn.holdOn += holdOn;
    }

    private void OnDisable()
    {
        _holdOn.slowlyDying -= FadingIn;
        _holdOn.holdOn -= holdOn;
    }

    private void FadingIn()
    {
        _fadeInAnim.Play("Fade In");
    }

    private void holdOn()
    {
        _fadeInAnim.Play("Fade Out");
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        _deathScreen.SetActive(true);
    }
}
