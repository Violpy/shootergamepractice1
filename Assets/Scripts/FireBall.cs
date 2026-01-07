using UnityEngine;

public class Fireball : MonoBehaviour
{
    public enum ProjectileType { Fireball, Lightning }
    
    [Header("Тип снаряда")]
    public ProjectileType type;

    [Header("Настройки")]
    public int damage = 10;
    public float lifetime = 2f;

    [Header("Настройки Огня (AOE)")]
    public float explosionRadius = 2f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            if (type == ProjectileType.Fireball)
            {
                // Логика Огня: Взрываемся и уничтожаем себя
                Explode();
                Destroy(gameObject);
            }
            else if (type == ProjectileType.Lightning)
            {
                // Логика Молнии: Наносим урон и НЕ уничтожаем себя (летим насквозь)
                Enemy enemy = col.GetComponent<Enemy>();
                if (enemy != null) enemy.TakeDamage(damage);
            }
        }

        // Если попали в препятствие (стену)
        if (col.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        // Ищем всех врагов в радиусе взрыва
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        
        foreach (Collider2D obj in objectsInRange)
        {
            if (obj.CompareTag("Enemy"))
            {
                Enemy enemy = obj.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }
    }

    // Отрисовка радиуса взрыва в редакторе для удобства
    void OnDrawGizmosSelected()
    {
        if (type == ProjectileType.Fireball)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }
    }
}