using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    public float jumpForce = 12f;
    public float dashSpeed = 16f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 3f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isDashing;
    private float dashTime;
    private float cooldownTimer;
    private float move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {      
        move = 0;
        if (Input.GetKey(KeyCode.A)) move = -1;
        if (Input.GetKey(KeyCode.D)) move = 1;

        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(3) && move != 0 && cooldownTimer <= 0)
        {
            isDashing = true;
            dashTime = dashDuration;
            cooldownTimer = dashCooldown;
        }

        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    
        if (move != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
        }
            
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0f);

    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            rb.linearVelocity = new Vector2(move * dashSpeed, rb.linearVelocity.y);
            dashTime -= Time.fixedDeltaTime;

            if (dashTime <= 0)
                isDashing = false;
        }
        else
        {
            rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
            isGrounded = false;
    }
}
