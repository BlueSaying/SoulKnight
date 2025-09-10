using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
public class PlayerSO : ScriptableObject
{
    public TextAsset textAsset;

    // 储存所有角色的列表
    [SerializeField]
    public List<PlayerStaticAttr> attrs = new List<PlayerStaticAttr>();

    private void OnValidate()
    {
        UnityTools.WriteDataToList(attrs, textAsset);
    }
}