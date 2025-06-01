using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int explosionDistance = 3;
    [SerializeField] GameObject fireSquarePrefab;

    private float explosionTimer;
    private MovementGrid grid;

    private void Awake()
    {
        grid = FindAnyObjectByType<MovementGrid>().GetComponent<MovementGrid>();
    }

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
        Vector3 origin = this.transform.position;
        Instantiate(fireSquarePrefab, origin, Quaternion.identity);

        // iterate the 4 directions to decide where to spawn

        for (int px = 0; px < explosionDistance; px++)
        {
            Vector3 spawnPositionXPos = origin + new Vector3(px+1, 0, 0);
            if (grid.GetGridSnap(spawnPositionXPos).built)
            {
                Instantiate(fireSquarePrefab, spawnPositionXPos, Quaternion.identity).transform.parent = null;
                break;
            }
            else
            {
                Instantiate(fireSquarePrefab, spawnPositionXPos, Quaternion.identity).transform.parent = null;
            }
        }

        for (int nx = 0; nx < explosionDistance; nx++)
        {
            Vector3 spawnPositionXNeg = origin + new Vector3(-nx-1, 0, 0);
            if (grid.GetGridSnap(spawnPositionXNeg).built)
            {
                Instantiate(fireSquarePrefab, spawnPositionXNeg, Quaternion.identity).transform.parent = null;
                break;
            }
            else
            {
                Instantiate(fireSquarePrefab, spawnPositionXNeg, Quaternion.identity).transform.parent = null;
            }
        }

        for (int py = 0; py < explosionDistance; py++)
        {
            Vector3 spawnPositionYPos = origin + new Vector3(0, 0, py+1);
            if (grid.GetGridSnap(spawnPositionYPos).built)
            {
                Instantiate(fireSquarePrefab, spawnPositionYPos, Quaternion.identity).transform.parent = null;
                break;
            }
            else
            {
                Instantiate(fireSquarePrefab, spawnPositionYPos, Quaternion.identity).transform.parent = null;
            }
        }

        for (int ny = 0; ny < explosionDistance; ny++)
        {
            Vector3 spawnPositionYNeg = origin + new Vector3(0, 0, -ny-1);
            if (grid.GetGridSnap(spawnPositionYNeg).built)
            {
                Instantiate(fireSquarePrefab, spawnPositionYNeg, Quaternion.identity).transform.parent = null;
                break;
            }
            else
            {
                Instantiate(fireSquarePrefab, spawnPositionYNeg, Quaternion.identity).transform.parent = null;
            }
        }


        Destroy(gameObject);
    }
}
