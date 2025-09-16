using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RocketLauncherData", menuName = "ScriptableObjects/WeaponData/RocketLauncherData")]
public class RocketLauncherSO : ScriptableObject
{
    public TextAsset textAsset;

    // 储存所有角色武器的列表
    [SerializeField]
    public List<RocketLauncherStaticAttr> attrs = new List<RocketLauncherStaticAttr>();

    private void OnValidate()
    {
        UnityTools.WriteDataToList(attrs, textAsset);
    }
}