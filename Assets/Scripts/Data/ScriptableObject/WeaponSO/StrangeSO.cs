using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StrangeData", menuName = "ScriptableObjects/WeaponData/StrangeData")]
public class StrangeSO : ScriptableObject
{
    public TextAsset textAsset;

    // 储存所有角色武器的列表
    [SerializeField]
    public List<StrangeStaticAttr> attrs = new List<StrangeStaticAttr>();

    private void OnValidate()
    {
        UnityTools.WriteDataToList(attrs, textAsset);
    }
}