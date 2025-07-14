using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSkinData", menuName = "ScriptableObjects/PlayerSkinData")]
public class PlayerSkinSO : ScriptableObject
{
    public TextAsset textAsset;

    // 储存所有角色皮肤的列表
    [SerializeField]
    public List<PlayerSkinStaticAttr> attrs = new List<PlayerSkinStaticAttr>();

    private void OnValidate()
    {
        UnityTools.Instance.WriteDataToList(attrs, textAsset);
    }
}