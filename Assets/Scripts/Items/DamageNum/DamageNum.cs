using UnityEngine;
using UnityEngine.UI;

public class DamageNum : Item
{
    private static readonly float risingSpeed = 1f;
    private static readonly float duration = 1f;    // 持续时间

    private float timer = 0f;
    private Text text;

    public DamageNum(GameObject gameObject, int damage, Color color) : base(gameObject)
    {
        text = transform.Find("Text").GetComponent<Text>();
        text.text = damage.ToString();
        text.color = color;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (timer < duration)
        {
            gameObject.transform.position += (Vector3)Vector2.up * risingSpeed * Time.deltaTime;
            Color textColor = text.color;
            textColor.a = 1 - timer / duration;
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