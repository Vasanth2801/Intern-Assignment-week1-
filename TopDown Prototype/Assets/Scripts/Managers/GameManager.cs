using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameoverPanel;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Time.timeScale = 1.0f;
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }


    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        gameoverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

}
