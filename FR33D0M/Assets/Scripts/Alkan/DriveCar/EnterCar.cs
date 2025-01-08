using Unity.VisualScripting;
using UnityEngine;

public class EnterCar : MonoBehaviour
{
    [SerializeField] float enterDistance = 2f;
    Collider2D ownCollider;
    PlayerRotation playerRotation;
    GameObject player;

    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().gameObject;
        ownCollider = player.GetComponent<Collider2D>();
        playerRotation = FindAnyObjectByType<PlayerRotation>();
    }

    void Update()
    {
        Vector2 rayDirection = Vector2.zero;
        if (!GetComponent<DriveCarSystem>().carObject.playerInCar) rayDirection = playerRotation.playerMouseRotation * Vector2.up;

        ownCollider.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, rayDirection, enterDistance);
        ownCollider.enabled = true;

        Debug.DrawLine(player.transform.position, player.transform.position + (Vector3)rayDirection * enterDistance, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<DriveCarSystem>() != null)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (hit.collider.GetComponent<DriveCarSystem>().carObject.playerInCar == true) CarLeave(hit);
                    else CarEnter(hit);
                }
            }
        }
    }

    void CarEnter(RaycastHit2D pHit)
    {
        pHit.collider.GetComponent<DriveCarSystem>().carObject.playerInCar = true;
        player.transform.SetParent(pHit.collider.transform);
        player.transform.localPosition = Vector3.zero;
        player.transform.localScale = Vector3.one;
        player.transform.rotation = pHit.collider.transform.rotation;
        player.SetActive(false);
    }
    
    void CarLeave(RaycastHit2D pHit)
    {
        pHit.collider.GetComponent<DriveCarSystem>().carObject.playerInCar = false;
        player.transform.SetParent(pHit.collider.transform.parent);
        player.transform.localPosition = new Vector3(pHit.collider.transform.position.x, pHit.collider.transform.position.y, pHit.collider.transform.position.x);
        player.transform.localScale = Vector3.one;
        player.transform.rotation = pHit.collider.transform.rotation;
        player.SetActive(true);
    }
}
