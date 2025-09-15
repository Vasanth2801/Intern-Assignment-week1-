using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawmInterval = 5f;
    private ObjectPoolManager poolManager;
    private float timer;

    public Transform spawnPoint;

    void Awake()
    {
        poolManager = FindObjectOfType<ObjectPoolManager>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            SpawnEnemy();
            timer = spawmInterval;
        }
    }

    void SpawnEnemy()
    {
        poolManager.SpawnObjects("Enemy", spawnPoint.position, spawnPoint.rotation);
    }


}
