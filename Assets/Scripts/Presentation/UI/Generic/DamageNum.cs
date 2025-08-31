using UnityEngine;
using UnityEngine.UI;

public class DamageNum : Item
{
    private static readonly float duration = 1.2f;    // 持续时间

    private float timer = 0f;
    private Text text;

    public DamageNum(GameObject gameObject, int damage, Color color, int fontSize) : base(gameObject)
    {
        text = transform.Find("Text").GetComponent<Text>();
        text.text = damage.ToString();
        text.fontSize = fontSize;
        text.color = color;

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(UnityTools.GetRandomFloat(-1, 1), 2).normalized * 5;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (timer < duration)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1 - 0.8f * timer / duration);
            timer += Time.deltaTime;
        }
        else
        {
            Remove();
        }
    }

    public virtual void Reset(Vector2 position, int damage, Color color, int fontSize)
    {
        base.Reset();
        timer = 0f;
        transform.position = position;
        text.text = damage.ToString();
        text.color = color;
        text.fontSize = fontSize;

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(UnityTools.GetRandomFloat(-1, 1), 2).normalized * UnityTools.GetRandomFloat(0.8f, 1.25f) * 5;
    }
}