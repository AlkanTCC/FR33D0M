using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Gemaakt door: Zeineb
    public float moveSpeed = 5f;
    private Vector2 movement;
    private Rigidbody2D rb;
    [SerializeField] Sprite playerSprite;
    SpriteRenderer spriteRenderer;

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY).normalized;

        if (movement != Vector2.zero) animator.enabled = true;
        else
        {
            animator.enabled = false;
            spriteRenderer.sprite = playerSprite;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }
}
