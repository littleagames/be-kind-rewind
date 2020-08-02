using System;
using UnityEngine;

public class TapeManager : MonoBehaviour
{
    private int _tapesRemaining;
    public event Action<int> OnTapesRemainingChanged;

    public void LoadTapes()
    {
        Debug.Log("TapeManager.LoadTapes");
        var tapes = GameObject.FindGameObjectsWithTag("Tape");
        if (tapes != null && tapes.Length > 0)
        {
            _tapesRemaining = tapes.Length;
            OnTapesRemainingChanged?.Invoke(_tapesRemaining);
        }
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
    }
}
