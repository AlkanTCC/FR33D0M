using UnityEngine;
using UnityEngine.UIElements;

// gemaakt door Jin aljumaili
public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    PlayerShoot playerShoot;
    Vector2 position;
    public bool enemyHit = false;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerShoot = FindFirstObjectByType<PlayerShoot>();
        player = FindAnyObjectByType<PlayerMovement>().gameObject;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyHit = true;
            enemyHit = false;
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        rb.linearVelocity = transform.up * 10;
        if (Vector2.Distance(playerShoot.firePoint.position, position) > playerShoot.currentWeapon.range)
        {
            print("out of range");
            gameObject.SetActive(false);
        }
    }

    public void Rotation()
    {
        transform.rotation = player.transform.rotation;
    }
}
