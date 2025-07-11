using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
public class PlayerScriptableObject : ScriptableObject
{
    [SerializeField]
    public List<PlayerShareAttr> attrs = new List<PlayerShareAttr>();
}