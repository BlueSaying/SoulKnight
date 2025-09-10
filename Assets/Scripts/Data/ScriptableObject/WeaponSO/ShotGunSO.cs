using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShotGunData", menuName = "ScriptableObjects/WeaponData/ShotGunData")]
public class ShotGunSO : ScriptableObject
{
    public TextAsset textAsset;

    // 储存所有角色武器的列表
    [SerializeField]
    public List<ShotGunStaticAttr> attrs = new List<ShotGunStaticAttr>();

    private void OnValidate()
    {
        UnityTools.WriteDataToList(attrs, textAsset);
    }
}