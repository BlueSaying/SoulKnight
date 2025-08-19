using UnityEngine;

public class BulletBasketball : Bullet
{
    private const int BounceTimes = 3;
    private int bounceCount = 0;

    public BulletBasketball(GameObject gameObject, Character owner, int damage) : base(gameObject, owner, damage) { }

    protected override void OnHitObstacle()
    {
        bounceCount++;

        if(bounceCount > BounceTimes)
        {
            base.OnHitObstacle();
        }
        else
        {
            transform.GetComponent<Rigidbody2D>().velocity *= -1;
        }
    }

    public override void Reset(Vector3 position, Quaternion quaternion)
    {
        base.Reset(position, quaternion);
        bounceCount = 0;
    }
}