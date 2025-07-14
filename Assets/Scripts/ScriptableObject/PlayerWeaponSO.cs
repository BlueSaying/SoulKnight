using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerWeaponData", menuName = "ScriptableObjects/PlayerWeaponData")]
public class PlayerWeaponSO : ScriptableObject
{
    public TextAsset textAsset;

    // 储存所有角色武器的列表
    [SerializeField]
    public List<PlayerWeaponStaticAttr> attrs = new List<PlayerWeaponStaticAttr>();

    private void OnValidate()
    {
        UnityTools.Instance.WriteDataToList(attrs, textAsset);
    }
}