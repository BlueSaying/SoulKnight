using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData_", menuName = "ScriptableObjects/LevelData")]
public class LevelSO : ScriptableObject
{
    // 储存所有关卡的列表
    [SerializeField]
    public LevelStaticAttr attrs;
}