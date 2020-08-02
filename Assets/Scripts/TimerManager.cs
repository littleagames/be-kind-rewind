using System;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public float TimePerLevel = 30f;
    public event Action<float> OnTimeRemainingChanged;

    private float _timeRemaining = 30f;
    private bool _timeStarted = false;

    public void ResetTime()
    {
        _timeRemaining = TimePerLevel;
        OnTimeRemainingChanged?.Invoke(_timeRemaining);
    }

    public void StartTime()
    {
        _timeStarted = true;
    }

    public float GetTimeRemaining()
    {
        return _timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeStarted && _timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
            OnTimeRemainingChanged?.Invoke(_timeRemaining);
        }
        else if (_timeRemaining <= 0f)
        {
            _timeStarted = false;
            _timeRemaining = 0f;
        }
    }
}
