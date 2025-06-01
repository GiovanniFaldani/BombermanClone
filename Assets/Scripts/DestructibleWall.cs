using UnityEngine;

public class DestructibleWall : Wall, IDamageable
{
    [SerializeField] private int health = 1;

    public void TakeDamage(int damage)
    {
        health -= damage;
        HealthCheck();
    }

    public void HealthCheck()
    {
        if (health <= 0) {
            grid.GetGridSnap(transform.position).built = false;
            Destroy(gameObject); 
        }
    }
}
