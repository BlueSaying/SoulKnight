using UnityEngine;

public class MoveManager
{
    private MoveManager() { }

    public static void Move(Rigidbody2D rb, Vector2 targetVelocity, float acceleration = 500f, float smoothingFactor = 200f)
    {
        rb.velocity = MoveToward(rb.velocity, targetVelocity, acceleration, smoothingFactor);
    }

    private static Vector2 MoveToward(Vector2 from, Vector2 to, float acceleration, float smoothingFactor)
    {
        float distance = Vector2.Distance(from, to);
        if (distance < acceleration * Time.fixedDeltaTime) // 如果目标速度和现在的速度之间的“距离”小于一个单位加速度
        {
            return to;  // 返回目标速度
        }
        else
        {
            float arg = acceleration * Mathf.Exp(-from.magnitude / smoothingFactor);
            return from + (to - from).normalized * Time.fixedDeltaTime * arg;   // 返回现速度加上一个指向目标速度的加速度
        }
    }
}