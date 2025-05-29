using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        UIManager.Instance.ShowUI(UIManager.GameUI.Win);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        UIManager.Instance.ShowUI(UIManager.GameUI.Lose);
    }
}
