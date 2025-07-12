using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
public class PlayerScriptableObject : ScriptableObject
{
    public TextAsset textAsset;

    [SerializeField]
    public List<PlayerShareAttr> attrs = new List<PlayerShareAttr>();

    private void OnValidate()
    {
        UnityTools.Instance.WriteDataToList(attrs, textAsset);
    }
}