using UnityEngine;
using System.Timers;
using System;


public class GameEventsManager : MonoBehaviour
{
    //Created with some help of Chat GPT, alot of it was just me doing research on timers however.
    //Things with comments above/next to them are useally things I used Chat GPT to help make

    [SerializeField] private float minTimeValue = 0f;
    [SerializeField] private float maxTimeValue = 10f;

    [SerializeField] private GameObject _tappingUI;
    [SerializeField] private Transform _canvasParent;
    [SerializeField] private ButtonManager _buttonManager;

    private Timer currentTimer;

    // Use this to queue actions back to main thread
    private Action mainThreadAction;

    public event Action startNewGameEvent;

    // Update is called once per frame
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
        _buttonManager.buttonPressed += StartTimer;
    }

    private void OnDisable()
    {
        _buttonManager.buttonPressed -= StartTimer;
    }


    private void SetNextEvent()
    {
        if (currentTimer != null)
        {
            currentTimer.Stop();
            currentTimer.Dispose();
        }

        float randomTime = UnityEngine.Random.Range(minTimeValue, maxTimeValue);
        currentTimer = new Timer(randomTime * 1000); // Timer interval is in milliseconds
        currentTimer.AutoReset = false; // We want to manually restart with new random interval
        currentTimer.Elapsed += OnTimerElapsed;
        currentTimer.Start();
    }

    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        // Queue the action to main thread
        mainThreadAction = () =>
        {
            OnTimerFinished();
            //SetNextEvent();  // Restart timer with new random interval
        };
    }

    private void OnTimerFinished()
    {
        GameObject newObject = Instantiate(_tappingUI, _canvasParent);
        Debug.Log("Timer finished, starting a new one.");
    }

    public void StartTimer()
    {
        SetNextEvent();
    }
}
