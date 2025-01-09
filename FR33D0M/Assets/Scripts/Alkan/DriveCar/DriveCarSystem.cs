using UnityEngine;

public class DriveCarSystem : MonoBehaviour
{
    // Gemaakt door: Alkan Cakir

    CarManager carManager;
    Rigidbody2D rb;
    public CarObject carObject;

    float currentSpeed = 0f;

    private void Start()
    {
        carManager = FindAnyObjectByType<CarManager>();

        rb = GetComponent<Rigidbody2D>();

        carObject = Instantiate(carManager.carObjectsArray[Random.Range(0, carManager.carObjectsArray.Length)]);

        GetComponent<SpriteRenderer>().sprite = carObject.sprite;
    }

    private void Update()
    {
        if (carObject.playerInCar) HandleMovement();
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += carObject.accelerationRate * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, carObject.maxSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= carObject.decelerationRate * Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, 0, carObject.maxSpeed);
            }
            else
            {
                currentSpeed -= carObject.accelerationRate * Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, -carObject.maxSpeed / 2, 0);
            }
        }
        else
        {
            currentSpeed -= carObject.decelerationRate * Time.deltaTime * Mathf.Sign(currentSpeed);
            currentSpeed = Mathf.Clamp(currentSpeed, -carObject.maxSpeed / 2, carObject.maxSpeed);
        }

        rb.linearVelocity = transform.up * currentSpeed;

        float turnInput = Input.GetAxis("Horizontal");

        if (currentSpeed != 0)
        {
            float scaledTurnSpeed = carObject.rotationRate * (Mathf.Abs(currentSpeed) / carObject.maxSpeed);
            transform.Rotate(Vector3.forward, -turnInput * scaledTurnSpeed * Time.deltaTime * Mathf.Sign(currentSpeed));
        }
    }
}