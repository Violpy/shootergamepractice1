using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Настройки движения")]
    public float speed = 5f;
    private float currentSpeed;
    private bool isSlowed = false;

    [Header("Настройки стрельбы")]
    public Transform firePoint;
    public float fireRateFireball = 0.5f; // Задержка для огня
    public float fireRateLightning = 0.15f; // Скорость для авто-атаки молнией
    private float nextShotTime;

    Rigidbody2D rb;
    Vector2 move;
    WeaponController weapon;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weapon = GetComponent<WeaponController>();
        currentSpeed = speed;
    }

    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        // Проверка нажатия мыши
        if (Input.GetMouseButton(0)) // GetMouseButton (без Down) позволяет зажимать кнопку
        {
            HandleShooting();
        }
    }

    void HandleShooting()
    {
        if (Time.time < nextShotTime) return;

        // Определяем задержку в зависимости от выбранного оружия
        // Огонь (Fire wand) — одиночные, Молния (Electric wand) — авто
        float currentRate = (weapon.GetCurrentPrefab().name.Contains("Fire")) ? fireRateFireball : fireRateLightning;
        
        ShootToMouse();
        nextShotTime = Time.time + currentRate;
    }

    void ShootToMouse()
    {
        if (weapon == null || firePoint == null) return;

        GameObject prefab = weapon.GetCurrentPrefab();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector2 direction = ((Vector2)mousePos - (Vector2)firePoint.position).normalized;
        GameObject bullet = Instantiate(prefab, firePoint.position, Quaternion.identity);
        
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {
            // Молния летает быстрее (High), Огонь медленнее (Medium)
            float bulletSpeed = (prefab.name.Contains("Fire")) ? 10f : 20f;
            bulletRb.linearVelocity = direction * bulletSpeed;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    // --- Код замедления от маленького паука (Shooter) ---
    public void ApplySlow(float slowAmount, float duration)
    {
        if (!isSlowed) StartCoroutine(SlowRoutine(slowAmount, duration));
    }

    System.Collections.IEnumerator SlowRoutine(float slowAmount, float duration)
    {
        isSlowed = true;
        currentSpeed = speed * slowAmount;
        yield return new WaitForSeconds(duration);
        currentSpeed = speed;
        isSlowed = false;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = move.normalized * currentSpeed;
    }
}