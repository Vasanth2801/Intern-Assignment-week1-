using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Time.timeScale = 1.0f;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("App Quitting");
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
