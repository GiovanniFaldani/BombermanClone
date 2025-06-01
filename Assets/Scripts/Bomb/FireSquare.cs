using UnityEngine;

public class FireSquare : MonoBehaviour
{
    public int damage = 1;
    private float duration = 1f;


    void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponentInParent<Enemy>().TakeDamage(damage);
        }
        else if (other.CompareTag("Player"))
        {
            other.GetComponentInParent<Player>().TakeDamage(damage);
        }
        else if (other.CompareTag("DestructibleWall"))
        {
            other.GetComponentInParent<DestructibleWall>().TakeDamage(damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponentInParent<Enemy>().TakeDamage(damage);
        }
        else if (other.CompareTag("Player"))
        {
            other.GetComponentInParent<Player>().TakeDamage(damage);
        }
        else if (other.CompareTag("DestructibleWall"))
        {
            other.GetComponentInParent<DestructibleWall>().TakeDamage(damage);
        }
    }
}
