using UnityEngine;

public class GameOver : MonoBehaviour
{
   


    public void Restart()
    {

        GameManager.instance.Restart();
    }

    public void MainMenu()
    {
        
        GameManager.instance.MainMenu();
    }
}
