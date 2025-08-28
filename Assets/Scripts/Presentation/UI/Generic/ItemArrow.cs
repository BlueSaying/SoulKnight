
// 物品指示箭头
using UnityEngine;
using UnityEngine.UI;

public class ItemArrow
{
    public Transform transform;

    public ItemArrow(Transform transform, string info, QualityType qualityType)
    {
        this.transform = transform;

        Text text = transform.Find("Info").GetComponent<Text>();
        text.text = info.ToChinese();

        switch (qualityType)
        {
            case QualityType.Blue:
                text.color = Color.blue;
                break;

            case QualityType.Green:
                text.color = Color.green;
                break;

            case QualityType.Orange:
                text.color = new Color(1f, 0.6f, 0);
                break;

            case QualityType.Purple:
                text.color = new Color(0.75f, 0, 1f);
                break;

            case QualityType.Red:
                text.color = Color.red;
                break;

            case QualityType.White:
                text.color = Color.white;
                break;
        }
    }
}