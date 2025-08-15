using Cinemachine;
using System;
using System.Collections.Generic;
using UnityEngine;



public class CameraSystem : BaseSystem
{
    private SceneName CurSceneName => SceneFacade.Instance.GetActiveSceneName();

    private GameObject cameraParent;

    public GameObject CameraParent
    {
        get
        {
            if (cameraParent == null) cameraParent = GameObject.Find("Cameras");
            if(cameraParent == null) throw new Exception("场景中无Cameras游戏物体！");
            return cameraParent;
        }
    }

    private Dictionary<MainMenuScene.CameraType, CinemachineVirtualCamera> MainMenuSceneCameras;
    private Dictionary<MiddleScene.CameraType, CinemachineVirtualCamera> MiddleSceneCameras;
    private Dictionary<BattleScene.CameraType, CinemachineVirtualCamera> BattleSceneCameras;

    public CameraSystem() { }

    protected override void OnInit()
    {
        base.OnInit();

        MainMenuSceneCameras = new Dictionary<MainMenuScene.CameraType, CinemachineVirtualCamera>();
        MiddleSceneCameras = new Dictionary<MiddleScene.CameraType, CinemachineVirtualCamera>();
        BattleSceneCameras = new Dictionary<BattleScene.CameraType, CinemachineVirtualCamera>();
    }

    protected override void OnEnter()
    {
        base.OnEnter();

        switch (CurSceneName)
        {
            case SceneName.MainMenuScene:
                break;
            case SceneName.MiddleScene:
                foreach (var cameraName in Enum.GetNames(typeof(MiddleScene.CameraType)))
                {
                    var cameraType = Enum.Parse<MiddleScene.CameraType>(cameraName);
                    var camera = UnityTools.Instance.GetComponentFromChildren<CinemachineVirtualCamera>(CameraParent, cameraName);
                    MiddleSceneCameras.Add(cameraType, camera);
                }
                SwitchCamera(MiddleScene.CameraType.StaticCamera);
                break;
            case SceneName.BattleScene:
                foreach (var cameraName in Enum.GetNames(typeof(BattleScene.CameraType)))
                {
                    var cameraType = Enum.Parse<BattleScene.CameraType>(cameraName);
                    var camera = UnityTools.Instance.GetComponentFromChildren<CinemachineVirtualCamera>(CameraParent, cameraName);
                    BattleSceneCameras.Add(cameraType, camera);
                }
                SwitchCamera(BattleScene.CameraType.FollowCamera);
                break;
        }
    }

    protected override void OnExit()
    {
        base.OnExit();

        switch (CurSceneName)
        {
            case SceneName.MainMenuScene:
                MainMenuSceneCameras.Clear();
                break;
            case SceneName.MiddleScene:
                MiddleSceneCameras.Clear();
                break;
            case SceneName.BattleScene:
                BattleSceneCameras.Clear();
                break;
        }
    }

    public void SetCameraTarget(MainMenuScene.CameraType type, Transform trans)
    {
        MainMenuSceneCameras[type].Follow = trans;
    }

    public void SetCameraTarget(MiddleScene.CameraType type, Transform trans)
    {
        MiddleSceneCameras[type].Follow = trans;
    }

    public void SetCameraTarget(BattleScene.CameraType type, Transform trans)
    {
        BattleSceneCameras[type].Follow = trans;
    }

    public void SwitchCamera(MainMenuScene.CameraType type)
    {
        foreach (var camera in MainMenuSceneCameras.Values)
        {
            camera.gameObject.SetActive(false);
        }

        MainMenuSceneCameras[type].gameObject.SetActive(true);
    }

    public void SwitchCamera(MiddleScene.CameraType type)
    {
        foreach (var camera in MiddleSceneCameras.Values)
        {
            camera.gameObject.SetActive(false);
        }

        MiddleSceneCameras[type].gameObject.SetActive(true);
    }

    public void SwitchCamera(BattleScene.CameraType type)
    {
        foreach (var camera in BattleSceneCameras.Values)
        {
            camera.gameObject.SetActive(false);
        }

        BattleSceneCameras[type].gameObject.SetActive(true);
    }
}