using System;
using UnityEngine;

public enum GameState
{
    WaitingToStart,
    InGame,
    Paused,
    GameOver,
    LevelCompleted
}

public class GameManager : MonoBehaviour
{
    public event Action<GameState> OnStateChange;
    public static GameManager Instance = null;

    private TapeManager _tapeManager;
    private TimerManager _timerManager;
    private GameState _gameState;

    public TapeManager GetTapeManager()
    {
        return _tapeManager;
    }

    public TimerManager GetTimerManager()
    {
        return _timerManager;
    }

    public GameState GetGameState()
    {
        return _gameState;
    }

    public bool IsInGame()
    {
        return _gameState == GameState.InGame;
    }

    public void SetGameState(GameState gameState)
    {
        _gameState = gameState;
        Debug.Log($"SetGameState: {gameState}");
        OnStateChange?.Invoke(gameState);
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
    }

    private void Start()
    {
        InitGame();
    }

    private void InitGame()
    {
        _gameState = GameState.WaitingToStart;
        _tapeManager.LoadTapes();
        _timerManager.ResetTime();
        _timerManager.StartTime();
    }
}
