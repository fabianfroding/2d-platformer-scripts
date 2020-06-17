using UnityEngine;

public class EnemyHarvester : Enemy
{
    [SerializeField]
    CircleCollider2D projectileSensor;

    Animator animator;

    private void Start()
    {
        health = 10;
        spriteRenderer = GetComponent<SpriteRenderer>();
        matWhite = (Material)Resources.Load("EnemyHarvesterWhiteFlash", typeof(Material));
        matDefault = spriteRenderer.material;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            Invoke("DestroySelf", 0f);
        }
    }

    public void Dodge(GameObject attacker, float offset)
    {
        animator.Play("Harvester_Dodge");
        Vector3 newPos = new Vector3(attacker.transform.position.x + offset, attacker.transform.position.y, 0);
        transform.position = newPos;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        Invoke("ResetAnim", 0.5f);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void ResetAnim()
    {
        animator.Play("Harvester_Idle");
    }

}
