using UnityEngine;

public class DriveCarSystem : MonoBehaviour
{
    // Gemaakt door: Alkan Cakir

    CarManager carManager;
    Rigidbody2D rb;

    [SerializeField] CarObject carObject;

    float speed;

    private void Start()
    {
        // Zoekt de CarManager script in de scene en zet die in de carManager
        carManager = FindAnyObjectByType<CarManager>();

        rb = GetComponent<Rigidbody2D>();

        // Gaat in de carManager en daarna in de carObjectsArray en pakt een random CarObject die in de array zit en zet die dan in de carObject
        carObject = carManager.carObjectsArray[Random.Range(0, carManager.carObjectsArray.Length)];
    }

    private void Update()
    {
        DriveSystem();

        print(speed);
    }

    void DriveSystem()
    {
        if (!CheckPlayerInCar()) return;

        rb.linearVelocity = new Vector2(0, speed);

        if (!CheckCarForward())
        {
            DecelerateCar();
            return;
        }

        AccelerateCar();
        ChangeDirection();
    }

    void AccelerateCar()
    {
        speed += carObject.initialAcceleration * Mathf.Pow(Time.time, 2) * carObject.accelerationRate * Time.deltaTime;

        speed = Mathf.Min(speed, carObject.maxSpeed);
    }

    void DecelerateCar()
    {
        speed -= carObject.initialAcceleration * Mathf.Pow(Time.time, 2) * carObject.decelerationRate * Time.deltaTime;
        speed = Mathf.Max(speed, 0);
    }

    void ChangeDirection()
    {
        if (Input.GetKey(KeyCode.A)) transform.Rotate(new Vector3(0, 0, 0.3f));
        else if (Input.GetKey(KeyCode.D)) transform.Rotate(new Vector3(0, 0, -0.3f));
    }

    bool CheckCarForward()
    {
        if (Input.GetKey(KeyCode.W)) return true;
        return false;
    }

    bool CheckPlayerInCar()
    {
        if (carObject.playerInCar) return true;
        return false;
    }
}