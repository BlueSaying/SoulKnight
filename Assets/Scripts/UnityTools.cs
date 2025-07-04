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
    public T GetComponentFromChildren<T>(GameObject obj, string name)
    {
        foreach (Transform t in obj.GetComponentsInChildren<Transform>())
        {
            if (t.name == name && t.GetComponent<T>() != null)
            {
                return t.GetComponent<T>();
            }
        }
        return default;
    }
}