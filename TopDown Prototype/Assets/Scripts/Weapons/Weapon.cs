using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/Weapon")]
public class Weapon : ScriptableObject
{
    // Weapon Information
    public string weaponName = "New Weapon";  // Name of the weapon
    public int damage = 10;                   // Damage dealt by the weapon
    public float fireRate = 0.5f;               // Fire rate of the weapon (shots per second)
    public int magazineSize;             // Magazine size of the weapon
}
