using UnityEngine;

public class ShootingEnemy : Enemy
{
    public GameObject webPrefab;
    public float shootInterval = 2f;
    private float timer;

    protected override void Update() 
    {
        
        base.Update(); 

        timer += Time.deltaTime;
        if (timer >= shootInterval)
        {
            ShootWeb();
            timer = 0;
        }
    }

    void ShootWeb()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null) return;
        
        GameObject web = Instantiate(webPrefab, transform.position, Quaternion.identity);
        Vector2 dir = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
        web.GetComponent<Rigidbody2D>().linearVelocity = dir * 5f;
    }
}