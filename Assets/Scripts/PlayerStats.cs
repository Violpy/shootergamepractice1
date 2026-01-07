using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [Header("Health Settings")]
    public int hpPerHeart = 20; 
    public int startHearts = 5; 
    
    public int maxHP;
    public int currentHP;
    public int score;

    [Header("Shield Settings")]
    public bool hasShield = false; 
    public GameObject shieldVisual;

    void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        
        maxHP = startHearts * hpPerHeart;
        currentHP = maxHP;
    }

    void Update()
    {
        if (shieldVisual != null)
        {
            shieldVisual.SetActive(hasShield);
        }
    }

    public void TakeDamage(int dmg)
    {
        if (hasShield)
        {
            hasShield = false; 
            return; 
        }

        currentHP -= dmg;
        if (currentHP <= 0) 
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHP = Mathf.Min(currentHP + amount, maxHP);
    }

    public void AddMaxHeart()
    {
        maxHP += hpPerHeart;
        currentHP += hpPerHeart;
    }

    void Die()
    {   
    if (WaveManager.Instance != null) {
        WaveManager.Instance.StopAllCoroutines();
    }

    if (SceneLoader.Instance != null)
    {
        SceneLoader.Instance.LoadScene("gameover");
    }
    }
}