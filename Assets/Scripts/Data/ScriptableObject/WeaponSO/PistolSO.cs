using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PistolData", menuName = "ScriptableObjects/WeaponData/PistolData")]
public class PistolSO : ScriptableObject
{
    public TextAsset textAsset;

    // 储存所有角色武器的列表
    [SerializeField]
    public List<PistolStaticAttr> attrs = new List<PistolStaticAttr>();

    private void OnValidate()
    {
        UnityTools.Instance.WriteDataToList(attrs, textAsset);
    }
}