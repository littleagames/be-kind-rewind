using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private TapeManager _tapeManager;

    public TapeManager GetTapeManager()
    {
        return _tapeManager;
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

        InitGame();
    }

    private void InitGame()
    {
        _tapeManager.LoadTapes();
    }
}
