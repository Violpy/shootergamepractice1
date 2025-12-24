using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int damage = 20;

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
