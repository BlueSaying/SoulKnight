using UnityEngine;
using UnityEngine.UI;

public class DamageNum : Item
{
    private static readonly float duration = 1f;    // 持续时间

    private float timer = 0f;
    private Text text;

    public DamageNum(GameObject gameObject, int damage, Color color) : base(gameObject)
    {
        text = transform.Find("Text").GetComponent<Text>();
        text.text = damage.ToString();
        text.color = color;

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(UnityTools.Instance.GetRandomFloat(-1, 1), 2).normalized * 5;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (timer < duration)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1 - 0.8f * timer / duration);
            timer += Time.deltaTime;
        }
        else
        {
            OnExit();
        }
    }

    protected override void OnExit()
    {
        base.OnExit();

        Object.Destroy(gameObject);
    }
}