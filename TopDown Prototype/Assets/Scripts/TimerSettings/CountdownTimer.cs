using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private float timer = 60f;
    [SerializeField] private TextMeshProUGUI timerText;

    public delegate void  GameOver();
    public static event GameOver onGameOver; 

    void Update()
    {
        timerText.text = timer.ToString();

        if(timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = "time: " + Mathf.Ceil(timer).ToString();
        }
        else
        {
            timerText.text = "Time: 0";
            onGameOver?.Invoke();
        }
    }
 }
