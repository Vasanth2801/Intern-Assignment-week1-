using UnityEngine;

public class Muzzle : MonoBehaviour
{
    [Header("Muzzle Settings")]
    [SerializeField] private GameObject firePoint;     // The point from which the bullet will be fired

    [Header("References")]
    ObjectPoolManager objectPoolManager;               // Reference to the ObjectPoolManager


    void Start()
    {
        objectPoolManager = FindObjectOfType<ObjectPoolManager>();           // Find the ObjectPoolManager in the scene
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))        // Check for space key press to shoot
        {
            Shoot();                                    // Call the Shoot method
        }
    }


    void Shoot()
    {
        objectPoolManager.SpawnObjects("Bullet", firePoint.transform.position, firePoint.transform.rotation);     // Spawn a bullet from the pool at the fire point's position and rotation
    }
}
