using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // Script gemaakt door Esat Yavuz

    [SerializeField] private float playerRotationSpeed = 3f;

    Vector2 mousePos;

    public Quaternion playerMouseRotation;

    // Update is called once per frame
    void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        RotatePlayerToMousePos();
    }

    void RotatePlayerToMousePos()
    {
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        playerMouseRotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, playerMouseRotation, playerRotationSpeed * Time.deltaTime);
    }
}
