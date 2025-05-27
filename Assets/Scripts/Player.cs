using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float bombTimer = 1; 

    // Input variables
    float x, y, bomb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Movement();
    }

    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        bomb = Input.GetAxis("Fire1");
    }

    private void Movement()
    {
        // Only allow cardinal movement
        if (x != 0) y = 0;
        if (y != 0) x = 0;

        Vector3 direction = new Vector3(x, 0, y).normalized;
        RaycastHit hit;
        Physics.Raycast(transform.position, direction, out hit, 0.25f); // raycast radius of capsule

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
