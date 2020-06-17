using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public Material matDefault;
    public Material matWhite;
    public SpriteRenderer spriteRenderer;

    public void ResetMaterial()
    {
        spriteRenderer.material = matDefault;
    }
}
