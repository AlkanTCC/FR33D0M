using UnityEngine;

[CreateAssetMenu(fileName = "WeaponObject", menuName = "Scriptable Objects/WeaponObject")]
public class Weapons : ScriptableObject
{
    public new string name;
    public string description;
    public int price;
    public float fireRate;
    public int damage;
    public int critRate;
    public int ammo;
    public float reloadTime;
    public float range;
}
