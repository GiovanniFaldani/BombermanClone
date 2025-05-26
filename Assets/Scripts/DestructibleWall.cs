using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    [SerializeField] private int hp = 1;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        HealthCheck();
    }

    private void HealthCheck()
    {
        if (hp <= 0) Destroy(this.gameObject);
    }
}
