using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private TapeManager _tapeManager;
    private TimerManager _timerManager;

    public TapeManager GetTapeManager()
    {
        return _tapeManager;
    }

    public TimerManager GetTimerManager()
    {
        return _timerManager;
    }

    private void Awake()
    {
        Debug.Log("GameManager.Awake()");
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        _tapeManager = GetComponent<TapeManager>();
        _timerManager = GetComponent<TimerManager>();

        InitGame();
    }

    private void InitGame()
    {
        _tapeManager.LoadTapes();
        _timerManager.ResetTime();
        _timerManager.StartTime();
    }
}
