using System;
using UnityEngine;

public enum CollectTapesState
{
    None,
    FindTapes,
    ReturnToRewinder
}

public class TapeManager : MonoBehaviour
{
    private int _tapesRemaining;
    public event Action<int> OnTapesRemainingChanged;
    public event Action<CollectTapesState> OnTapeStateChanged;

    private CollectTapesState _collectTapesState = CollectTapesState.None;

    public void LoadTapes()
    {
        Debug.Log("TapeManager.LoadTapes");
        var tapes = GameObject.FindGameObjectsWithTag("Tape");
        if (tapes != null)
        {
            if (tapes.Length > 0)
            {
                _tapesRemaining = tapes.Length;
                OnTapesRemainingChanged?.Invoke(_tapesRemaining);
            }
        }

        SetCollectTapeState(CollectTapesState.FindTapes);
    }

    public int GetTapesRemaining()
    {
        return _tapesRemaining;
    }

    public void CollectTape()
    {
        Debug.Log("TapeManager.CollectTape");
        _tapesRemaining--;
        OnTapesRemainingChanged?.Invoke(_tapesRemaining);

        if (_tapesRemaining <= 0)
        {
            _tapesRemaining = 0;
            SetCollectTapeState(CollectTapesState.None);
            GameManager.Instance.SetGameState(GameState.LevelCompleted);
            return;
        }

        SetCollectTapeState(CollectTapesState.FindTapes);
    }

    public void SetCollectTapeState(CollectTapesState state)
    {
        _collectTapesState = state;
        OnTapeStateChanged?.Invoke(state);
    }
}
