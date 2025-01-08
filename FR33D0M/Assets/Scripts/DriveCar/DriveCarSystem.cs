using UnityEngine;

public class DriveCarSystem : MonoBehaviour
{
    // Gemaakt door: Alkan Cakir

    CarManager carManager;
    Rigidbody2D rb;

    CarObject newCarObject;

    public CarObject carObject;

    float speed;

    float accelerationTime;

    bool isBreaking = false;

    private void Start()
    {
        // Zoekt de CarManager script in de scene en zet die in de carManager
        carManager = FindAnyObjectByType<CarManager>();

        rb = GetComponent<Rigidbody2D>();

        // Gaat in de carManager en daarna in de carObjectsArray en pakt een random CarObject die in de array zit en zet die dan in de carObject
        newCarObject = carManager.carObjectsArray[Random.Range(0, carManager.carObjectsArray.Length)];
        carObject = Instantiate(newCarObject);

        accelerationTime = carObject.accelerationStartTime;

        GetComponent<SpriteRenderer>().sprite = carObject.sprite;
    }

    private void Update()
    {
        DriveSystem();
    }

    void DriveSystem()
    {
        // Beweeg de auto omhoog keer de speed
        rb.linearVelocity = transform.up * speed;

        if (speed < 0 && !CheckPlayerInCar()) speed = 0;

        if (!CheckCarForward())
        {
            DecelerateCar();
        }

        // Als de player niet in de auto zit gebeurd de code hier onder niet
        if (!CheckPlayerInCar()) return;

        if (speed != 0) ChangeDirection();

        CheckBreakCar();

        if (!CheckCarForward()) return;

        AccelerateCar();
    }

    void AccelerateCar()
    {
        // Dit zorgt ervoor dat de speed value steeds sneller omhoog gaat
        speed += carObject.initialAcceleration * Mathf.Pow(accelerationTime, 2) * carObject.accelerationRate * Time.deltaTime;

        // Dit zorgt ervoor dat de kleinste nummer van de twee gereturned word. Dat zorgt ervoor dat de speed niet boven de max speed komt
        speed = Mathf.Min(speed, carObject.maxSpeed);
    }

    void DecelerateCar()
    {
        speed -= carObject.initialAcceleration * Mathf.Pow(accelerationTime, 2) * carObject.decelerationRate * Time.deltaTime;
        
        if (!isBreaking) speed = Mathf.Max(speed, 0);

        if (speed == 0) accelerationTime = carObject.accelerationStartTime;
    }

    void ChangeDirection()
    {
        // Rotate de auto naar links of naar rechts (licht eraan welke knop je indrukt)
        if (Input.GetKey(KeyCode.A)) transform.Rotate(new Vector3(0, 0, carObject.rotationRate * speed));
        else if (Input.GetKey(KeyCode.D)) transform.Rotate(new Vector3(0, 0, -carObject.rotationRate * speed));
    }

    void CheckBreakCar()
    {
        if (Input.GetKey(KeyCode.S))
        {
            isBreaking = true;
            BreakCar();
        }
        else if (Input.GetKeyUp(KeyCode.S)) isBreaking = false;
    }

    void BreakCar()
    {
        speed = speed - carObject.breakRate * Time.deltaTime;
        speed = Mathf.Max(speed, -5);
    }

    bool CheckCarForward()
    {
        if (Input.GetKey(KeyCode.W))
        {
            accelerationTime += Time.deltaTime;
            accelerationTime = Mathf.Min(accelerationTime, 2);
            return true;
        }

        return false;
    }

    bool CheckPlayerInCar()
    {
        if (carObject.playerInCar) return true;
        return false;
    }
}