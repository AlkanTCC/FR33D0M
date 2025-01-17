using Unity.VisualScripting;
using UnityEngine;

public class EnterCar : MonoBehaviour
{
    [SerializeField] float enterDistance = 2f;
    Collider2D ownCollider;
    PlayerRotation playerRotation;
    GameObject player;

    bool isInCar = false;

    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().gameObject;
        ownCollider = player.GetComponent<Collider2D>();
        playerRotation = FindAnyObjectByType<PlayerRotation>();
    }

    void Update()
    {
        if (isInCar) player.transform.localPosition = Vector3.zero;

        Vector2 rayDirection = Vector2.zero;
        Quaternion rotation = Quaternion.Euler(0, 0, 180);
        if (!GetComponent<DriveCarSystem>().carObject.playerInCar) rayDirection = (playerRotation.playerMouseRotation * rotation) * Vector2.up;

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
        isInCar = true;
        pHit.collider.GetComponent<DriveCarSystem>().carObject.playerInCar = true;
        player.transform.SetParent(pHit.collider.transform);
        player.transform.localPosition = new Vector3(0, 0, 0);
        player.transform.rotation = pHit.collider.transform.rotation;
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<PlayerRotation>().enabled = false;
        player.GetComponent<BoxCollider2D>().enabled = false;
    }
    
    void CarLeave(RaycastHit2D pHit)
    {
        isInCar = false;
        pHit.collider.GetComponent<DriveCarSystem>().carObject.playerInCar = false;
        player.transform.SetParent(pHit.collider.transform.parent);
        player.transform.localPosition = new Vector3(pHit.collider.transform.position.x, pHit.collider.transform.position.y, 0);
        player.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        player.transform.rotation = pHit.collider.transform.rotation;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<PlayerRotation>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
    }
}
