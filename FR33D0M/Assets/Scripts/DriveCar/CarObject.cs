using UnityEngine;

[CreateAssetMenu(fileName = "CarObject", menuName = "Scriptable Objects/CarObject")]
public class CarObject : ScriptableObject
{
    // Gemaakt door: Alkan Cakir

    public new string name;

    public float maxSpeed;

    public float initialAcceleration;
    public float accelerationRate;

    public float decelerationRate;

    public bool openSeat;
    public bool playerInCar;
}
