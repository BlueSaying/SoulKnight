using UnityEngine;

public class Bullet_5 : BasePlayerBullet
{
    public Bullet_5(GameObject gameObject) : base(gameObject) { }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (Physics2D.OverlapCircle(position, 0.01f, LayerMask.GetMask("Obstacle")))
        {
            Remove();
        }

        transform.position += rotation * Vector2.right * 30 * Time.deltaTime;
    }

}
