using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinePool : MonoBehaviour
{
    public static CoroutinePool Instance
    {
        get
        {
            GameObject obj = GameObject.Find("CoroutinePool");
            if (obj == null)
            {
                obj = new GameObject("CoroutinePool", typeof(CoroutinePool));
            }

            return obj.GetComponent<CoroutinePool>();
        }
    }

    private Dictionary<object, List<Coroutine>> dic;

    private void Awake()
    {
        dic = new Dictionary<object, List<Coroutine>>();
    }

    /// <summary>
    /// 开启协程
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="coroutine"></param>
    /// <returns></returns>
    public void StartCoroutine(object obj, IEnumerator coroutine)
    {
        if (dic.ContainsKey(obj))
        {
            dic[obj].Add(StartCoroutine(coroutine));
        }
        else
        {
            dic.Add(obj, new List<Coroutine>() { StartCoroutine(coroutine) });
        }
    }

    public void StopAllCoroutine(object obj)
    {
        if (dic.ContainsKey(obj))
        {
            foreach (Coroutine coroutine in dic[obj])
            {
                StopCoroutine(coroutine);
            }
            dic[obj].Clear();
        }
    }
}