using UnityEngine;

public class BaseBullet : Item
{
    private const float speed = 30f;
    public BaseBullet(GameObject gameObject) : base(gameObject) { }

    protected override void OnExit()
    {
        base.OnExit();

        Object.Destroy(gameObject);
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (Physics2D.OverlapCircle(position, 0.01f, LayerMask.GetMask("Obstacle")))
        {
            Remove();

            if (hasRemoved == true)
            {
                OnHitObstacle();

            }
        }

        // TODO:后期改为BaseBullet.speed
        transform.position += rotation * Vector2.right * speed * Time.deltaTime;
    }

    protected virtual void OnHitObstacle() { }
}