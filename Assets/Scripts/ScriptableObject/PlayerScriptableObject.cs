using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
public class PlayerScriptableObject : ScriptableObject
{
    public TextAsset textAsset;

    // 储存所有角色的列表
    [SerializeField]
    public List<PlayerShareAttr> playershareAttrs = new List<PlayerShareAttr>();

    private void OnValidate()
    {
        UnityTools.Instance.WriteDataToList(playershareAttrs, textAsset);
    }
}