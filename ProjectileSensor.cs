using UnityEngine;

public class ProjectileSensor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Projectile") && col.gameObject.GetComponent<Projectile>().source.CompareTag("Player"))
        {
            GameObject parent = transform.parent.gameObject;
            GameObject attacker = col.gameObject.GetComponent<LightSphere>().source;
            float offset = -3f;
            if (attacker.GetComponent<PlayerController>().spriteRenderer.flipX)
            {
                offset = -offset;
            }
            parent.GetComponent<Harvester>().Dodge(attacker, offset);
        }
    }
}
