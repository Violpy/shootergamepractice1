using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.SetState(GameState.Playing);
        SceneLoader.Instance.LoadScene("lvl");
    }

    public void OpenSettingsFromMenu()
    {
        GameManager.Instance.previousScene = PreviousScene.MainMenu;
        SceneLoader.Instance.LoadScene("setting1");
    }

    public void OpenSettingsFromGame()
    {
        GameManager.Instance.previousScene = PreviousScene.lvl;
        SceneLoader.Instance.LoadScene("setting1");
    }

    public void BackFromSettings()
    {
        if (GameManager.Instance.previousScene == PreviousScene.MainMenu)
            SceneLoader.Instance.LoadScene("MainMenu");
        else
            GameManager.Instance.ResumeGame();
    }

    public void Pause()
    {
        GameManager.Instance.PauseGame();
        SceneLoader.Instance.LoadScene("pause");
    }

    public void Resume()
    {
        GameManager.Instance.ResumeGame();
        SceneLoader.Instance.LoadScene("lvl");
    }

    public void Restart()
    {
        SceneLoader.Instance.LoadScene("lvl");
    }
    public void ResumeGame()
    {
        SceneLoader.Instance.LoadScene("lvl");
    }
    public void GoToInventory()
    {
        SceneLoader.Instance.LoadScene("inventory");
    }

public void GoToMainMenu()
    {
        SceneLoader.Instance.LoadScene("MainMenu");
    }

    public void Quit()
{
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
}
}
