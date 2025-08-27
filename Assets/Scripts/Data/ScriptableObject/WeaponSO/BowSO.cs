using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BowData", menuName = "ScriptableObjects/WeaponData/BowData")]
public class BowSO : ScriptableObject
{
    public TextAsset textAsset;

    // 储存所有角色武器的列表
    [SerializeField]
    public List<BowStaticAttr> attrs = new List<BowStaticAttr>();

    private void OnValidate()
    {
        UnityTools.Instance.WriteDataToList(attrs, textAsset);
    }
}