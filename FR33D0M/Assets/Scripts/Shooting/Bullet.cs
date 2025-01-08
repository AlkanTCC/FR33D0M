using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    PlayerShoot playerShoot;
    Vector2 position;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerShoot = FindFirstObjectByType<PlayerShoot>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        rb.linearVelocity = new Vector2(0, 10);
        if (Vector2.Distance(playerShoot.firePoint.position, position) > playerShoot.currentWeapon.range)
        {
            print("out of range");
            gameObject.SetActive(false);
        }
    }

}
