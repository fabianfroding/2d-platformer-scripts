using UnityEngine;

public class LightSphere : MonoBehaviour
{
    public GameObject source;

    [SerializeField]
    AudioSource deathSound;

    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    private float timedLife = 0.7f;
    private Vector3 rotate;

    private void Start()
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

    private void FixedUpdate()
    {
        float moveSpeed = 5.5f;
        if (spriteRenderer.flipX)
        {
            moveSpeed = -5.5f;
        }
        rb2d.velocity = new Vector2(moveSpeed, 0);
    }

    private void DestroySelf()
    {
        spriteRenderer.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, deathSound.clip.length);
    }

    private void DestroySelfWithSound()
    {
        deathSound.Play();
        DestroySelf();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            DestroySelfWithSound();
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            enemy.spriteRenderer.material = enemy.matWhite;
            enemy.health--;
            if (enemy.health > 0)
            {
                enemy.Invoke("ResetMaterial", 0.1f);
            }
        }
    }
}
