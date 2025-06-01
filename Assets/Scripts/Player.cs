using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int health = 1;
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] float bombCooldownTime = 1;
    [SerializeField] private float explosionTimer = 2;
    [SerializeField] GameObject bombPrefab;

    // Input variables
    float x, y, bomb;
    private float bombCooldownTimer;

    // grid
    private MovementGrid grid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bombCooldownTimer = 0;
        grid = FindAnyObjectByType<MovementGrid>().GetComponent<MovementGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Movement();
        CheckPlaceBomb();
    }

    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        bomb = Input.GetAxis("Fire1");
    }

    private void Movement()
    {
        // lock to a single axis
        if (Mathf.Abs(x) > Mathf.Abs(y)) y = 0;
        else x = 0;

        Vector3 direction = new Vector3(x, 0, y).normalized;
        Vector3 originY = new Vector3(transform.position.x, 0, transform.position.y + 0.25f);
        RaycastHit hit;
        Physics.SphereCast(transform.position, 0.4f, direction, out hit, 0.1f);

        // avoid moving when near walls
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Wall") ||
                hit.collider.CompareTag("DestructibleWall")) return;
        }

        transform.Translate(direction * moveSpeed * Time.deltaTime);
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void CheckPlaceBomb()
    {
        bombCooldownTimer -= Time.deltaTime;
        bombCooldownTimer = Mathf.Max(bombCooldownTimer, 0);
        if (bomb > 0 && bombCooldownTimer <=0)
        {
            // get current plaer position and snap a bomb to the closes grid spot
            Vector3 spawnPosition = grid.GetGridSnap(transform.position).worldPosition;
            GameObject bomb = Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
            bomb.transform.parent = null;
            bomb.GetComponent<Bomb>().SetBombTimer(explosionTimer);
            bombCooldownTimer = bombCooldownTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        HealthCheck();
    }

    public void HealthCheck()
    {
        if (health <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}
