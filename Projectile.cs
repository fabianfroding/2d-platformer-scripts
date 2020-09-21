using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject source;

    [SerializeField]
    protected AudioSource deathSound;

    protected Rigidbody2D rb2d;
    protected SpriteRenderer spriteRenderer;
    protected float timedLife;
    protected float moveSpeed;
    protected int damage;

    protected virtual void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (source.GetComponent<Unit>().isFacingLeft) moveSpeed = -moveSpeed;
        Invoke("DestroySelf", timedLife);
    }

    protected void DestroySelf()
    {
        spriteRenderer.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, deathSound.clip.length);
    }

    protected void DestroySelfWithSound()
    {
        deathSound.Play();
        DestroySelf();
    }

    protected void OnTriggerEnter2D(Collider2D col)
    {
        DestroySelfWithSound();
        if ((col.gameObject != source.gameObject) &&
            (source.CompareTag("Player") && col.CompareTag("Enemy")) || 
            (source.CompareTag("Enemy") && col.CompareTag("Player")))
        {
            Unit target = col.gameObject.GetComponent<Unit>();
            target.spriteRenderer.material = target.matWhite;
            target.health -= damage;

            if (target.CompareTag("Player")) target.GetComponent<Player>().UpdateHealthText();

            if (target.health > 0)
            {
                target.Invoke("ResetMaterial", 0.1f);
            }
        }
    }
}
