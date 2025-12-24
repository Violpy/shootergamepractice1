using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject firePrefab;
    public Transform firePoint;

    Rigidbody2D rb;
    Vector2 move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(1)) 
            ShootToMouse();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = move.normalized * speed;
    }

    void ShootToMouse()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        Vector2 direction = (mouseWorldPos - firePoint.position).normalized;

        GameObject fire = Instantiate(firePrefab, firePoint.position, Quaternion.identity);
        fire.GetComponent<Rigidbody2D>().linearVelocity = direction * 10f;
    }
}

