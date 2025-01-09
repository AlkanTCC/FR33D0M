using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // Script gemaakt door Esat Yavuz

    [SerializeField] private float playerRotationSpeed = 5f;

    Vector2 mousePos;

    Quaternion playerMouseRotation;

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        RotatePlayerToMousePos();
    }

    void RotatePlayerToMousePos()
    {
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        playerMouseRotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, playerMouseRotation, playerRotationSpeed * Time.deltaTime);
    }
}
