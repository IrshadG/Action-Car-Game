using UnityEngine;

[CreateAssetMenu(fileName = "Car")]
public class BaseCar : ScriptableObject
{
    public GameObject carPrefab;
    public float maxSpeed;
    public float maxHP;
    public float handling;
}
