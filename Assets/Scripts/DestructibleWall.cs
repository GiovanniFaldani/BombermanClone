using UnityEngine;

public class DestructibleWall : Wall
{
    [SerializeField] private int hp = 1;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        HealthCheck();
    }

    private void HealthCheck()
    {
        if (hp <= 0) {
            grid.GetGridSnap(transform.position).built = false;
            Destroy(this.gameObject); 
        }
    }
}
