using System;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var timerManager = GameManager.Instance.GetTimerManager();
        timerManager.OnTimeRemainingChanged += OnTimeRemainingChanged;

        SetTimeText(timerManager.GetTimeRemaining());
    }

    private void OnDestroy()
    {
        var timerManager = GameManager.Instance.GetTimerManager();
        timerManager.OnTimeRemainingChanged -= OnTimeRemainingChanged;
    }

    private void OnTimeRemainingChanged(float timeRemaining)
    {
        //Debug.Log("TimerText.OnTimeRemainingChanged");
        SetTimeText(timeRemaining);
    }

    private void SetTimeText(float timeRemaining)
    {
        var timerText = GetComponent<TMPro.TMP_Text>();
        var minutes = (int)timeRemaining / 60;
        var seconds = (int)timeRemaining % 60;
        timerText.SetText($"{minutes:00}:{seconds:00}");
    }
}
