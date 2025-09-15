using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float enemySpeed = 3f;
    public Transform kill;

    void Start()
    {
        kill = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(kill != null)
        {
            Vector2 direction = (kill.position - transform.position).normalized;
            transform.Translate(direction * enemySpeed * Time.deltaTime);
        }
    }
}
