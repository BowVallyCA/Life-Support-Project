using UnityEngine;

public class FadingControl : MonoBehaviour
{
    [SerializeField] private HoldOn _holdOn;
    [SerializeField] private Animator _fadeInAnim;

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

    private void GameOver()
    {
        Debug.Log("You died, may you rest in peace :(");
    }
}
