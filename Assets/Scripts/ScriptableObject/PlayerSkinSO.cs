using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSkinData", menuName = "ScriptableObjects/PlayerSkinData")]
public class PlayerSkinSO : ScriptableObject
{
    public TextAsset textAsset;

    // 储存所有角色皮肤的列表
    [SerializeField]
    public List<PlayerSkinAttr> playerSkinAttrs = new List<PlayerSkinAttr>();

    private void OnValidate()
    {
        UnityTools.Instance.WriteDataToList(playerSkinAttrs, textAsset);
    }
}