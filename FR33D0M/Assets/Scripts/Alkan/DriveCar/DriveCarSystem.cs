using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DriveCarSystem : MonoBehaviour
{
    // Gemaakt door: Alkan Cakir

    TMP_Text speedText;

    CarManager carManager;
    Rigidbody2D rb;
    public CarObject carObject;

    public float currentSpeed = 0f;

    private void Start()
    {
        speedText = GameObject.FindGameObjectWithTag("SpeedText").GetComponent<TMP_Text>();

        carManager = FindAnyObjectByType<CarManager>();

        rb = GetComponent<Rigidbody2D>();

        carObject = Instantiate(carManager.carObjectsArray[Random.Range(0, carManager.carObjectsArray.Length)]);

        GetComponent<SpriteRenderer>().sprite = carObject.sprite;
    }

    private void Update()
    {
        if (carObject.playerInCar)
        {
            HandleMovement();
            speedText.text = ((int)(currentSpeed * 10)).ToString();
        }

        ApplyDeceleration();
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (currentSpeed < 0) // If reversing, decelerate to zero first
            {
                currentSpeed += carObject.decelerationRate * 2f * Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, -carObject.maxSpeed / 2, 0);
            }
            else // Normal acceleration when not reversing
            {
                currentSpeed += carObject.accelerationRate * Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, 0, carObject.maxSpeed);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (currentSpeed > 0) // If moving forward, decelerate to zero first
            {
                currentSpeed -= carObject.decelerationRate * 2f * Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, 0, carObject.maxSpeed);
            }
            else // Normal reverse acceleration when not moving forward
            {
                currentSpeed -= carObject.accelerationRate * Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, -carObject.maxSpeed / 2, 0);
            }
        }

        float turnInput = Input.GetAxis("Horizontal");

        if (currentSpeed != 0)
        {
            float scaledTurnSpeed = carObject.rotationRate * 1.25f * (Mathf.Abs(currentSpeed) / carObject.maxSpeed);
            transform.Rotate(Vector3.forward, -turnInput * scaledTurnSpeed * Time.deltaTime * Mathf.Sign(currentSpeed));
        }
    }


    void ApplyDeceleration()
    {
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && currentSpeed != 0)
        {
            currentSpeed -= carObject.decelerationRate * Time.deltaTime * Mathf.Sign(currentSpeed);
            currentSpeed = Mathf.Clamp(currentSpeed, -carObject.maxSpeed / 2, carObject.maxSpeed);
        }

        rb.linearVelocity = transform.up * currentSpeed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<NPCWalkingSystem>() != null) collision.gameObject.GetComponent<NPCWalkingSystem>().CarCollision(this);
    }
}