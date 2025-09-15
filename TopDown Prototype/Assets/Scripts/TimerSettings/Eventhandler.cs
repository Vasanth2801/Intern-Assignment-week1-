using UnityEngine;

public class Eventhandler : MonoBehaviour
{
   void OnEnable()
   {
        CountdownTimer.onGameOver += GameOver;
   }

   void OnDisable()
   {
        CountdownTimer.onGameOver -= GameOver;
   }

    public void GameOver()
    {
        Debug.Log("GameOver!");
    }
}
