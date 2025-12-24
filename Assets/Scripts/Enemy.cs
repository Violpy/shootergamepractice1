using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 40;
    public float speed = 2f;
    public int damage = 10;

    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            PlayerStats.Instance.score += 10;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerStats.Instance.TakeDamage(damage);
        }
    }
}
