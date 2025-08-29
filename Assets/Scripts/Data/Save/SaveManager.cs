using System.IO;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    private static readonly string savePath = Application.streamingAssetsPath + "GlobalData.json";

    private SaveManager() { }

    private GlobalData globalData;
    public GlobalData GlobalData
    {
        get
        {
            if (globalData == null)
            {
                LoadData();
            }

            return globalData;
        }
    }

    public void SaveData()
    {
        if (globalData == null)
        {
            globalData = new GlobalData();
        }

        string json = JsonUtility.ToJson(globalData);
        File.WriteAllText(savePath, json);
    }

    public void LoadData()
    {
        if (!File.Exists(savePath))
        {
            globalData = new GlobalData();
            return;
        }

        string data = File.ReadAllText(savePath);
        globalData = JsonUtility.FromJson<GlobalData>(data);
    }

    public void SetData(GlobalData globalData)
    {
        this.globalData = globalData;
    }
}