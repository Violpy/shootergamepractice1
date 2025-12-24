using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public int maxHP = 100;
    public int currentHP;
    public int score;

    void Awake()
    {
        Instance = this;
        currentHP = maxHP;
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
            Die();
    }

    void Die()
    {
        GameManager.Instance.SetState(GameState.GameOver);
        SceneLoader.Instance.LoadScene("gameover");
    }
}
