using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float runSpeed = 3.5f;
    [SerializeField]
    private float jumpSpeed = 5f;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    Transform groundCheckL;

    [SerializeField]
    Transform groundCheckR;

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    Object lightSphereRef;

    private bool isGrounded;
    private bool attack0AnimPlaying;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lightSphereRef = Resources.Load("LightSphere");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.Play("Seer_Attack0");
            attack0AnimPlaying = true;
            Invoke("ResetAnim", 0.15f);
            GameObject lightSphere = (GameObject)Instantiate(lightSphereRef);
            float x = 0.6f;

            if (spriteRenderer.flipX)
            {
                x = -.4f;
                lightSphere.GetComponent<SpriteRenderer>().flipX = true;
            }
            lightSphere.transform.position = new Vector3(transform.position.x + x, transform.position.y + -0.03f, -1);
        }
    }

    void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            if (isGrounded && !attack0AnimPlaying)
            {
                animator.Play("Seer_Run");
            }
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            if (isGrounded && !attack0AnimPlaying)
            {
                animator.Play("Seer_Run");
            }
            spriteRenderer.flipX = true;
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            if (isGrounded && !attack0AnimPlaying)
            {
                animator.Play("Seer_Idle");
            }
        }

        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            animator.Play("Seer_Jump");
        }
    }

    void ResetAnim()
    {
        attack0AnimPlaying = false;
    }
}
