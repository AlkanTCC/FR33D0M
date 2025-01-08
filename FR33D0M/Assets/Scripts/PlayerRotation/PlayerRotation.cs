using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // Script gemaakt door Esat Yavuz

    bool mouseToMovement = false;

    public float distanceToMouse = 4f;
    public float playerRotationSpeed = 5f;

    Vector2 mousePos;

    Quaternion playerMoveRotation;
    Quaternion playerMouseRotation;

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (Vector2.Distance(transform.position, mousePos) < distanceToMouse)
        {
            RotatePlayerToMovement();
            return;
        }
        else
        {
            mouseToMovement = true;
            RotatePlayerToMousePos();
        }
    }

    void RotatePlayerToMousePos()
    {
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        playerMouseRotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, playerMouseRotation, playerRotationSpeed * Time.deltaTime);
    }

    void RotatePlayerToMovement()
    {
        if (mouseToMovement)
        {
            playerMoveRotation = playerMouseRotation;
            mouseToMovement = false;
        }

        if (Input.GetKey(KeyCode.W)) playerMoveRotation = Quaternion.AngleAxis(0, Vector3.forward);
        if (Input.GetKey(KeyCode.A)) playerMoveRotation = Quaternion.AngleAxis(-270, Vector3.forward);
        if (Input.GetKey(KeyCode.S)) playerMoveRotation = Quaternion.AngleAxis(-180, Vector3.forward);
        if (Input.GetKey(KeyCode.D)) playerMoveRotation = Quaternion.AngleAxis(-90, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, playerMoveRotation, playerRotationSpeed * Time.deltaTime);
    }
}
