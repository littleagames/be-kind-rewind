using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject WaitToStartMenu;
    public GameObject GameOverMenu;
    public GameObject LevelCompletedMenu;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnStateChange += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnStateChange -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.WaitingToStart:
                WaitToStartMenu.SetActive(true);
                GameOverMenu.SetActive(false);
                LevelCompletedMenu.SetActive(false);
                break;
            case GameState.GameOver:
                WaitToStartMenu.SetActive(false);
                GameOverMenu.SetActive(true);
                LevelCompletedMenu.SetActive(false);
                break;
            case GameState.LevelCompleted:
                WaitToStartMenu.SetActive(false);
                GameOverMenu.SetActive(false);
                LevelCompletedMenu.SetActive(true);
                break;
            default:
                WaitToStartMenu.SetActive(false);
                GameOverMenu.SetActive(false);
                LevelCompletedMenu.SetActive(false);
                break;
        }
    }

    public void RestartLevel()
    {
        GameManager.Instance.ResetGame();
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
