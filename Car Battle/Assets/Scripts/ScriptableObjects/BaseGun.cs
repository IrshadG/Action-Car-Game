using UnityEngine;

[CreateAssetMenu(fileName = "Gun")]
public class BaseGun : ScriptableObject
{
    public GameObject gunPrefab;
    public float maxAmmo;
    public float fireRate;
    public float damageRate;
    public float critRate;
}