using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] float speed = 3f;
    [SerializeField] float offsetMultitude = 2.25f;

    GameObject player;
    DriveCarSystem car;
    Camera cam;


    private void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().gameObject;
        car = FindAnyObjectByType<DriveCarSystem>();
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        cam.orthographicSize = Mathf.Clamp(1.00001f * car.currentSpeed, 6, 8);
        if (car.carObject.playerInCar) PlayerInCarCamera();
        else PlayerCamera();
    }

    void PlayerCamera()
    {
        offset.x = Input.GetAxisRaw("Horizontal") * offsetMultitude;
        offset.y = Input.GetAxisRaw("Vertical") * offsetMultitude;
        transform.position = Vector3.Slerp(transform.position, new Vector3((player.transform.position + offset).x, (player.transform.position + offset).y, -10), speed * Time.deltaTime);
    }

    void PlayerInCarCamera()
    {
        if (car.currentSpeed >= -1.1f) transform.position = Vector3.Slerp(transform.position, new Vector3(car.transform.GetChild(0).transform.position.x, car.transform.GetChild(0).transform.position.y, -10), speed * Time.deltaTime);
        else transform.position = Vector3.Slerp(transform.position, new Vector3(car.transform.GetChild(1).transform.position.x, car.transform.GetChild(1).transform.position.y, -10), speed * Time.deltaTime);
    }
}