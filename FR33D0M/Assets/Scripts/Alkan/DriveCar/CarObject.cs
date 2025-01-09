using UnityEngine;

[CreateAssetMenu(fileName = "CarObject", menuName = "Scriptable Objects/CarObject")]
public class CarObject : ScriptableObject
{
    // Gemaakt door: Alkan Cakir

    [Header("Information")]
    public new string name;
    public Sprite sprite;

    [Header("Speed")]
    public float maxSpeed;

    [Header("Acceleration")]
    public float accelerationRate;

    [Header("Deceleration")]
    public float decelerationRate;

    [Header("Break")]
    public float breakRate;

    [Header("Rotation")]
    public float rotationRate;

    [Header("Car")]
    public bool playerInCar;
}
