using UnityEngine;

public class LightSphere : Projectile
{
    private Vector3 rotate;

    protected override void Start()
    {
        timedLife = 0.7f;
        moveSpeed = 5.6f;
        damage = 1;
        rotate = new Vector3(0, 0, -500);
        base.Start();
    }

    private void Update()
    {
        transform.Rotate(rotate * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(moveSpeed, 0);
    }
}
