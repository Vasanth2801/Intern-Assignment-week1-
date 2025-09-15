using UnityEngine;

public class Menu : MonoBehaviour
{
    

    public void PlayGame()
    {
        GameManager.instance.Play();
    }

    public void Quit()
    {
        GameManager.instance.Quit();
    }
}
