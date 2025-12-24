using UnityEngine;

public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    GameOver
}

public enum PreviousScene
{
    MainMenu,
    lvl
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentState;
    public PreviousScene previousScene;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetState(GameState state)
    {
        CurrentState = state;
        Time.timeScale = (state == GameState.Playing) ? 1f : 0f;
    }

    public void PauseGame()
    {
        SetState(GameState.Paused);
        SceneLoader.Instance.LoadScene("pause");
    }

    public void ResumeGame()
    {
        SetState(GameState.Playing);
        SceneLoader.Instance.LoadScene("lvl");
    }
}
