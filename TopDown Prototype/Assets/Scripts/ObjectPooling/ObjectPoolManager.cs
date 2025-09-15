using UnityEngine;
using System.Collections.Generic;

public class ObjectPoolManager : MonoBehaviour
{
    // Define a class to hold the pool information
    [System.Serializable]
    public class ObjectPool
    {
        public string poolName;                               // Name to identify the pool
        public GameObject prefab;                             // Prefab to be pooled
        public int poolSize;                                  // Number of objects to pre-instantiate
    }

    public List<ObjectPool> pools;                             // List of pools to manage
    Dictionary<string, Queue<GameObject>> poolDictionary;      // Dictionary to hold the pools

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();              // Initialize the dictionary

        foreach (ObjectPool item in pools)                                      // Loop through each pool defined in the inspector
        {
            Queue<GameObject> obj = new Queue<GameObject>();                       // Create a new queue for the pool

            for (int i = 0; i < item.poolSize; i++)
            {
                GameObject objPool = Instantiate(item.prefab);                    // Instantiate the prefab
                objPool.SetActive(false);                                         // Deactivate the object
                obj.Enqueue(objPool);                                             // Add the object to the queue
            }

            poolDictionary.Add(item.poolName, obj);                               // Add the queue to the dictionary with the pool name as the key
        }
    }

    // Method to spawn an object from the pool
    public GameObject SpawnObjects(string poolName, Vector3 position, Quaternion rotation)
    {
       GameObject objectToSpawn = poolDictionary[poolName].Dequeue();              // Get the next object from the pool
        objectToSpawn.SetActive(true);                                        // Activate the object
        objectToSpawn.transform.position = position;                             // Set the position
        objectToSpawn.transform.rotation = rotation;                          // Set the rotation

        poolDictionary[poolName].Enqueue(objectToSpawn);                             // Add the object back to the end of the queue


        return objectToSpawn;                                        // Return the spawned object
    }

}

