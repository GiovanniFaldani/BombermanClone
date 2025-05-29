using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float minDecTimer = 0.5f;
    [SerializeField] private float maxDecTimer = 2;

    // Input variables
    Vector3 movementDirection = new Vector3();
    private Vector3[] directions = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
    float inputTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputTimer = maxDecTimer;
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
        Physics.Raycast(transform.position, direction, out hit, 0.5f); // raycast radius of capsule

        // avoid moving when near walls
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Wall") ||
                hit.collider.CompareTag("DestructibleWall")) return;
        }

        transform.Translate(direction * moveSpeed * Time.deltaTime);
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
