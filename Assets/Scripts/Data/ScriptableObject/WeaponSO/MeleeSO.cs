using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeData", menuName = "ScriptableObjects/WeaponData/MeleeData")]
public class MeleeSO : ScriptableObject
{
    public TextAsset textAsset;

    // 储存所有角色武器的列表
    [SerializeField]
    public List<MeleeStaticAttr> attrs = new List<MeleeStaticAttr>();

    private void OnValidate()
    {
        UnityTools.WriteDataToList(attrs, textAsset);
    }
}