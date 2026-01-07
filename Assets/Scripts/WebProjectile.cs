using UnityEngine;

public class WebProjectile : MonoBehaviour
{
    public float slowFactor = 0.5f; // На сколько замедляет (50%)
    public float slowDuration = 3f; // На сколько секунд

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerController pc = col.GetComponent<PlayerController>();
            if (pc != null) pc.ApplySlow(slowFactor, slowDuration);
            Destroy(gameObject); 
        }
    }
}