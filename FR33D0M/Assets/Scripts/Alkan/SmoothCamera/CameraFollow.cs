using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] float speed = 3f;
    [SerializeField] float offsetMultitude = 3f;

    GameObject player;
    DriveCarSystem car;


    private void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().gameObject;
        car = FindAnyObjectByType<DriveCarSystem>();
    }

    private void LateUpdate()
    {
        if (car.carObject.playerInCar) PlayerInCarCamera();
        else PlayerCamera();
        transform.position = Vector3.Slerp(transform.position, new Vector3((player.transform.position + offset).x, (player.transform.position + offset).y, -10), speed * Time.deltaTime);
    }

    void PlayerCamera()
    {

        offset.x = Input.GetAxisRaw("Horizontal") * offsetMultitude;
        offset.y = Input.GetAxisRaw("Vertical") * offsetMultitude;
    }

    void PlayerInCarCamera()
    {
        offset.x = car.transform.rotation.z * offsetMultitude;
        offset.y = car.transform.rotation.z * offsetMultitude;
    }
}