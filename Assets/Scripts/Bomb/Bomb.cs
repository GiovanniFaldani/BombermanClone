using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int explosionDistance = 3;
    [SerializeField] GameObject fireSquarePrefab;

    private float explosionTimer;

    // Update is called once per frame
    void Update()
    {
        explosionTimer -= Time.deltaTime;
        if (explosionTimer < 0)
        {
            Explode();
        }
    }

    public void SetBombTimer(float timer)
    {
        explosionTimer = timer;
    }

    // Compute where to spawn explosions based on GridSquare built attribute
    private void Explode()
    {

        Destroy(gameObject);
    }
}
