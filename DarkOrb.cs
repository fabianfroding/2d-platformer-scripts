using UnityEngine;

public class DarkOrb : Projectile
{
    protected override void Start()
    {
        timedLife = 1.4f;
        moveSpeed = 5.4f;
        damage = 1;
        base.Start();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(moveSpeed, 0);
    }
}
