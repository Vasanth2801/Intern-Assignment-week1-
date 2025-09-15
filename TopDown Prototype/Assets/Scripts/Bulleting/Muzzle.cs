using UnityEngine;
using System.Collections.Generic;   

public class Muzzle : MonoBehaviour
{
    [Header("Muzzle Settings")]
    [SerializeField] private GameObject firePoint;     // The point from which the bullet will be fired

    [Header("References")]
    ObjectPoolManager objectPoolManager;               // Reference to the ObjectPoolManager

    [Header("Weapon Settings")]
    public Weapon weaponName;                         // current weapon
    public Weapon[] weapons;                          // Array of weapons (if multiple weapons are used)
    int currentWeaponIndex;                          // current weapon index
    int currentMag;                                    // Current ammunition in the magazine
    float nextFire;                                     // Time until the next shot can be fired
    public int maxMag = 40;


    void Start()
    {
        currentWeaponIndex = 0;
        currentMag = maxMag;
        objectPoolManager = FindObjectOfType<ObjectPoolManager>();           // Find the ObjectPoolManager in the scene
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))        // Check for space key press to shoot
        {
            Shoot();                                    // Call the Shoot method

            if(currentMag > 0)
            {
                currentMag--;                          // Decrease the current magazine count
            }

            if(currentMag < 0)
            {
                Debug.Log("Out of ammo");
            }
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                currentWeaponIndex++;
                Debug.Log("Weapon switched");
            }
        }
        
    }

    public void Shoot()
    {
        AudioManager.instance.FireSound();
        objectPoolManager.SpawnObjects("Bullet", firePoint.transform.position, firePoint.transform.rotation);     // Spawn a bullet from the pool at the fire point's position and rotation

        if (Time.time < nextFire)
        {
            return;  // Check if the weapon can fire again based on the fire rate
        }
    }
}
