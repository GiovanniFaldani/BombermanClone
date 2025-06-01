using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int health = 1;
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float minDecTimer = 0.5f;
    [SerializeField] private float maxDecTimer = 2;
    public int damage = 1;

    // Input variables
    Vector3 movementDirection = new Vector3();
    private Vector3[] directions = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
    float inputTimer;

    // Enemy Counter
    private EnemyCounter ec;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputTimer = maxDecTimer;
        ec = FindAnyObjectByType<EnemyCounter>().GetComponent<EnemyCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        RandomInput();
        Movement();
    }

    private void RandomInput()
    {
        if (inputTimer > 0)
        {
            inputTimer -= Time.deltaTime;
            if (inputTimer < 0)
            {
                // pick a random cardinal direction
                movementDirection = directions[Random.Range(0, directions.Length)];
                inputTimer = Random.Range(minDecTimer, maxDecTimer);
            }
        }
    }

    private void Movement()
    {
        

        Vector3 direction = movementDirection;
        RaycastHit hit;
        Physics.SphereCast(transform.position,0.4f,  direction, out hit, 0.1f); // raycast radius of capsule

        // avoid moving when near walls
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Wall") ||
                hit.collider.CompareTag("DestructibleWall")) return;
        }

        transform.Translate(direction * moveSpeed * Time.deltaTime);
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        HealthCheck();
    }

    public void HealthCheck()
    {
        if(health < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        ec.RemoveEnemy();
    }
}
