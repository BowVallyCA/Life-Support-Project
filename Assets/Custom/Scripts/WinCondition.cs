using UnityEngine;
using System.Timers;
using System;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private HoldOn _holdOn;
    [SerializeField] private float _winNumber = 300f;
    [SerializeField] private GameObject _winScreen;

    private Action mainThreadAction;

    void Update()
    {
        // Run queued actions on main thread
        if (mainThreadAction != null)
        {
            mainThreadAction.Invoke();
            mainThreadAction = null;
        }
    }

    private void OnEnable()
    {
        _holdOn.startGame += StartTimer;
    }

    private void OnDisable()
    {
        _holdOn.startGame -= StartTimer;
    }


    private void StartTimer()
    {
        Timer timeTillWin = new Timer(_winNumber * 1000);
        timeTillWin.Elapsed += DisplayWinScreen;
        timeTillWin.Start();
    }

    private void DisplayWinScreen(object sender, ElapsedEventArgs e)
    {
        mainThreadAction = () =>
        {
            Debug.Log("You Won!");
            _winScreen.SetActive(true);
            Time.timeScale = 0f;
        };
    }
}
