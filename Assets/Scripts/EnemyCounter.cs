using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public int enemyCount;

    void Start()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
    }

    public void RemoveEnemy()
    {
        enemyCount--;
        CheckWin();
    }

    private void CheckWin()
    {
        if (enemyCount <= 0) GameManager.Instance.WinGame();
    }
}
