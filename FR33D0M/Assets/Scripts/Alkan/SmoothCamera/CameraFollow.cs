using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] float speed = 5f;

    Transform player;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3((player.position + offset).x, (player.position + offset).y, -10), speed * Time.deltaTime);
    }
}