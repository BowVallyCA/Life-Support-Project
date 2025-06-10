using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HoldOn  _holdOn;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _breathAudioSource;

    private void OnEnable()
    {
        _holdOn.startGame += StartGame;
    }

    private void OnDisable()
    {
        _holdOn.startGame -= StartGame;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator.Play("Flash");
    }

    private void StartGame()
    {
        _animator.Play("Fade");
        _breathAudioSource.Play();
    }
}
