using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData")]
public class EnemySO : ScriptableObject
{
    public TextAsset textAsset;

    // 储存所有敌人的列表
    [SerializeField]
    public List<EnemyStaticAttr> attrs = new List<EnemyStaticAttr>();

    private void OnValidate()
    {
        UnityTools.WriteDataToList(attrs, textAsset);
    }
}
