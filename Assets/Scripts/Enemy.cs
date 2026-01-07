using UnityEngine;

// Создаем структуру для настройки лута
[System.Serializable]
public struct LootItem {
    public GameObject prefab;
    [Range(0, 100)] public int chance; // Индивидуальный шанс для этого предмета
}

public class Enemy : MonoBehaviour
{
    public int hp = 40;
    public float speed = 2f;
    public int damage = 10;

    [Header("Настройки Лута")]
    public LootItem[] lootTable; // Список предметов с их шансами

    [Header("Настройки Танка (Large Spider)")]
    public bool isTank = false;
    public GameObject minionPrefab;

    protected Transform player;

    protected virtual void Start() {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) player = p.transform;
    }

    protected virtual void Update() {
        if (player == null) return;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int dmg) {
        hp -= dmg;
        if (hp <= 0) Die();
    }

    void Die() {
        PlayerStats.Instance.score += 10;
        
        // Логика танка: спавн маленьких пауков
        if (isTank && minionPrefab != null) {
            Instantiate(minionPrefab, transform.position + Vector3.right * 0.5f, Quaternion.identity);
            Instantiate(minionPrefab, transform.position + Vector3.left * 0.5f, Quaternion.identity);
        }

        TryDropLoot();
        Destroy(gameObject);
    }

    void TryDropLoot() {
        foreach (LootItem item in lootTable) {
            int roll = Random.Range(0, 101);
            if (roll <= item.chance) {
                Instantiate(item.prefab, transform.position, Quaternion.identity);
                // Если хочешь, чтобы выпадал только один предмет за раз, добавь здесь break;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Player")) {
            PlayerStats.Instance.TakeDamage(damage);
        }
    }
}