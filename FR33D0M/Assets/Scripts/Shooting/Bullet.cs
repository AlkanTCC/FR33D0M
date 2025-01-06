using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerShoot playerShoot;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerShoot = GetComponent<PlayerShoot>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * 500);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hitEnemy");
            //Destroy(this.gameObject);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
