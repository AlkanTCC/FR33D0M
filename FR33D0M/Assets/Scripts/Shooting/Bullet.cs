using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    PlayerShoot playerShoot;
    Vector2 position;
    Vector2 posAtShooting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerShoot = FindFirstObjectByType<PlayerShoot>();
        posAtShooting = transform.position;
        
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
        print($"position at shooting >{posAtShooting}, position of bullet > {position}");
        if (Vector2.Distance(playerShoot.firePoint.position, position) > playerShoot.currentWeapon.range)
        {
            print("out of range");
            gameObject.SetActive(false);
        }
    }

}
