using UnityEngine;

public class LightSphere : MonoBehaviour
{
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    private float timedLife = 0.7f;
    private Vector3 rotate;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rotate = new Vector3(0, 0, -500);
        Invoke("DestroySelf", timedLife);
    }

    private void Update()
    {
        transform.Rotate(rotate * Time.deltaTime);
    }

    void FixedUpdate()
    {
        float moveSpeed = 5.5f;
        if (spriteRenderer.flipX)
        {
            moveSpeed = -5.5f;
        }
        rb2d.velocity = new Vector2(moveSpeed, 0);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
