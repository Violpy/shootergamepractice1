using UnityEngine;

public enum UpgradeType { FirstAid, Feather, Shield }

public class UpgradeItem : MonoBehaviour
{
    public UpgradeType type;
    public float lifetime = 15f; // Время жизни баффа

    void Start()
    {
        // Удалить этот бафф через 15 секунд после появления
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            ApplyUpgrade();
            Destroy(gameObject); // Удаляем сразу, если игрок его подобрал
        }
    }

    void ApplyUpgrade() {
        if (PlayerStats.Instance == null) return;
        var stats = PlayerStats.Instance;
        
        switch (type) {
            case UpgradeType.FirstAid:
                stats.Heal(20); 
                break;
            case UpgradeType.Feather:
                stats.AddMaxHeart();
                break;
            case UpgradeType.Shield:
                stats.hasShield = true;
                Debug.Log("Щит активирован!");
                break;
        }
    }
}