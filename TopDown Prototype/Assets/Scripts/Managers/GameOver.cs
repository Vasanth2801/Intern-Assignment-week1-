using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;


    public void Restart()
    {
        gameOverPanel.SetActive(false);
        GameManager.instance.Restart();
    }

    public void MainMenu()
    {
        gameOverPanel.SetActive(true);
        GameManager.instance.MainMenu();
    }
}
