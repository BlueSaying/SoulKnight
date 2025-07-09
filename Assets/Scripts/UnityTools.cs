using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class UnityTools
{
    private static UnityTools _instance;
    public static UnityTools Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UnityTools();
            }
            return _instance;
        }
    }
    private UnityTools() { }

    /// <summary>
    /// 在父对象的所有子层级中查找指定名称的物体，并获取其上的指定类型组件
    /// </summary>
    /// <typeparam name="T">要获取的组件类型</typeparam>
    /// <param name="parent">要搜索的父对象（会递归搜索所有层级的子物体）</param>
    /// <param name="name">要查找的子物体名称</param>
    /// <returns>
    /// 找到时：返回匹配的第一个子物体上的T类型组件；
    /// 未找到时：返回null
    /// </returns>
    /// <remarks>
    /// 注意：
    /// 1. 会搜索父对象自身及其所有层级的子对象
    /// 2. 需要同时满足名称匹配和组件存在两个条件
    /// 3. 只返回第一个找到的匹配项
    /// 4. 对性能敏感的场景慎用（遍历所有子对象+多次GetComponent调用）
    /// </remarks>
    public T GetComponentFromChildren<T>(GameObject parent, string name, bool isActive = false)
    {
        foreach (Transform t in parent.GetComponentsInChildren<Transform>(!isActive))
        {
            if (t.name == name && t.GetComponent<T>() != null)
            {
                return t.GetComponent<T>();
            }
        }
        return default;
    }

    /// <summary>
    /// 在父对象的所有子层级中查找指定名称的Transform
    /// </summary>
    /// <param name="parent">要搜索的父对象（会递归搜索所有子对象）</param>
    /// <param name="name">要查找的子物体名称（区分大小写）</param>
    /// <returns>
    /// 找到时：返回匹配的第一个子物体的Transform组件；
    /// 未找到时：返回null（default）
    /// </returns>
    public Transform GetTransformFromChildren(GameObject parent, string name, bool isActive = false)
    {
        foreach (Transform t in parent.GetComponentsInChildren<Transform>(!isActive))
        {
            if (t.name == name)
            {
                return t;
            }
        }

        return default;
    }
}