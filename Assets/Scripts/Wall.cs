using UnityEngine;

public class Wall : MonoBehaviour
{
    protected MovementGrid grid;

    protected void Awake()
    {
        grid = FindAnyObjectByType<MovementGrid>();
    }

    protected void Start()
    {
        grid.GetGridSnap(transform.position).built = true;
    }
}
