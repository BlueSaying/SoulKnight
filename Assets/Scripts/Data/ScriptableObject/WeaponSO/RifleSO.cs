using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RifleData", menuName = "ScriptableObjects/WeaponData/RifleData")]
public class RifleSO : ScriptableObject
{
    public TextAsset textAsset;

    // 储存所有角色武器的列表
    [SerializeField]
    public List<RifleStaticAttr> attrs = new List<RifleStaticAttr>();

    private void OnValidate()
    {
        UnityTools.Instance.WriteDataToList(attrs, textAsset);
    }
}