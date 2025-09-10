using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StaffData", menuName = "ScriptableObjects/WeaponData/StaffData")]
public class StaffSO : ScriptableObject
{
    public TextAsset textAsset;

    // 储存所有角色武器的列表
    [SerializeField]
    public List<StaffStaticAttr> attrs = new List<StaffStaticAttr>();

    private void OnValidate()
    {
        UnityTools.WriteDataToList(attrs, textAsset);
    }
}