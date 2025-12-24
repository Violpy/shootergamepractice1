using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            GameManager.Instance.SetState(GameState.GameOver);
            SceneLoader.Instance.LoadScene("gameover");
        }
    }
}
