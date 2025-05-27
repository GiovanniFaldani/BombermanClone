using UnityEngine;

public class GameManager : MonoBehaviour
{

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
