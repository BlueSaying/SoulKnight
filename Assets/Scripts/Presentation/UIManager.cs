//using System.Collections.Generic;
//using UnityEngine;

//public class UIManager
//{
//    //根节点
//    private Transform _ui_root;
//    public Transform UI_Root
//    {
//        get
//        {
//            if (_ui_root == null) _ui_root = GameObject.Find("Canvas").transform;
//            return _ui_root;
//        }
//    }

//    /// <summary>
//    /// 存储界面名称和资源路径的映射
//    /// </summary>
//    private Dictionary<string, string> path_dictionary;

//    /// <summary>
//    /// 预制件缓存字典
//    /// </summary>
//    private Dictionary<string, GameObject> prefab_dictionary;

//    /// <summary>
//    /// 储存已经打开界面的缓存字典
//    /// </summary>
//    public Dictionary<string, Panel> panel_dictionary;

//    private static UIManager _instance;
//    public static UIManager Instance
//    {
//        get
//        {
//            if (_instance == null) _instance = new UIManager();
//            return _instance;
//        }
//    }

//    //构造函数
//    private UIManager()
//    {
//        Init_Dictionary();
//    }

//    /// <summary>
//    /// 初始化UI字典数据
//    /// </summary>
//    private void Init_Dictionary()
//    {
//        path_dictionary = UI_Const.path_dictionary;//界面名称，界面路径
//        prefab_dictionary = new Dictionary<string, GameObject>();//界面名称，界面预制体
//        panel_dictionary = new Dictionary<string, Panel>();//界面名称，界面类
//    }

//    /// <summary>
//    /// 检测UI界面是否被打开
//    /// </summary>
//    /// <param name="panel_name">要检测的UI界面的名称</param>
//    /// <returns>若界面已打开则返回true,反之返回false</returns>
//    public bool Is_Panel_Opened(string panel_name)
//    {
//        return panel_dictionary.ContainsKey(panel_name);
//    }

//    /// <summary>
//    /// 打开UI界面
//    /// </summary>
//    /// <param name="panel_name">要打开的UI界面的名称</param>
//    /// <returns>打开的界面的Base_Panel</returns>
//    public Panel Open_Panel(string panel_name)
//    {
//        Panel panel = null;
//        //检查是否已经打开
//        if (panel_dictionary.TryGetValue(panel_name, out panel))
//        {
//            Debug.Log("界面已打开" + panel_name);
//            return null;
//        }

//        //检查路径是否有配置
//        string path = "";
//        if (!path_dictionary.TryGetValue(panel_name, out path))
//        {
//            Debug.LogError("界面名称错误，或者未配置路径：" + panel_name);
//            return null;
//        }

//        //使用缓存的预制件
//        GameObject panel_prefab = null;
//        if (!prefab_dictionary.TryGetValue(panel_name, out panel_prefab))//检查预制体中是否已经储存了该界面
//        {
//            string real_path = "Prefabs/Panel/" + path;
//            panel_prefab = Resources.Load<GameObject>(real_path) as GameObject;
//            prefab_dictionary.Add(panel_name, panel_prefab);
//        }

//        //打开UI界面
//        GameObject panel_object = Object.Instantiate(panel_prefab, UI_Root, false);//从预制体中实例化一个新的界面
//        panel = panel_object.GetComponent<Panel>();
//        panel_dictionary.Add(panel_name, panel);
//        panel.OpenPanel(panel_name);
//        return panel;
//    }

//    /// <summary>
//    /// 关闭UI界面
//    /// </summary>
//    /// <param name="panel_name">要关闭的UI界面的名称</param>
//    /// <returns>是否成功打开UI界面</returns>
//    public bool Close_Panel(string panel_name)
//    {
//        Panel panel = null;
//        if (!panel_dictionary.TryGetValue(panel_name, out panel))//检测要关闭的界面有没有被打开
//        {
//            Debug.LogError("界面未打开" + panel_name);
//            return false;
//        }

//        panel.ClosePanel();
//        return true;
//    }


//}