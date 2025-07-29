using Cinemachine;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenuScene
{
    public enum CameraType
    {

    }
}

namespace MiddleScene
{
    public enum CameraType
    {
        /// <summary>
        /// 刚进游戏时，选择角色时的相机
        /// </summary>
        StaticCamera,

        /// <summary>
        /// 选中某个角色后，对该角色特写的相机
        /// </summary>
        SelectingCamera,

        /// <summary>
        /// 角色选择完成后，始终跟随角色的相机
        /// </summary>
        FollowCamera
    }
}

namespace BattleScene
{
    public enum CameraType
    {

    }
}



public class CameraSystem : BaseSystem
{
    private SceneName CurSceneName => SceneFacade.Instance.GetActiveSceneName();

    private GameObject cameraParent;

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

        cameraParent = GameObject.Find("Cameras");

        if (cameraParent == null)
        {
            throw new Exception("场景中无Cameras游戏物体！");
        }

        switch (CurSceneName)
        {
            case SceneName.MainMenuScene:
                break;
            case SceneName.MiddleScene:
                foreach (var cameraName in Enum.GetNames(typeof(MiddleScene.CameraType)))
                {
                    var cameraType = Enum.Parse<MiddleScene.CameraType>(cameraName);
                    var camera = UnityTools.Instance.GetComponentFromChildren<CinemachineVirtualCamera>(cameraParent, cameraName);
                    MiddleSceneCameras.Add(cameraType, camera);
                }
                SwitchCamera(MiddleScene.CameraType.StaticCamera);
                break;
            case SceneName.BattleScene:
                break;
        }


    }

    protected override void OnExit()
    {
        base.OnExit();

        cameraParent = null;
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

    public void SetCameraTarget(MiddleScene.CameraType type, Transform trans)
    {
        MiddleSceneCameras[type].Follow = trans;
    }

    // NOTE:每次调用完，记得同时调用SetCameraTarget
    public void SwitchCamera(MiddleScene.CameraType type)
    {
        // 全部禁用
        foreach (var camera in MiddleSceneCameras.Values)
        {
            camera.gameObject.SetActive(false);
        }

        MiddleSceneCameras[type].gameObject.SetActive(true);
    }
}