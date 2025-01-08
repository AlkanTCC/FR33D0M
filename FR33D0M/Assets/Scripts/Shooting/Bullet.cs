using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    //PlayerShoot playerShoot;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
        rb.linearVelocity = new Vector2(0, 10);
    }

}
