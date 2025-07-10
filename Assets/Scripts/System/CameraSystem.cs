using Cinemachine;
using UnityEngine;

public enum CameraType
{
    /// <summary>
    /// 刚进游戏时，选择角色时的相机
    /// </summary>
    staticCamera,

    /// <summary>
    /// 选中某个角色后，对该角色特写的相机
    /// </summary>
    selectingCamera,

    /// <summary>
    /// 角色选择完成后，始终跟随角色的相机
    /// </summary>
    followCamera
}

public class CameraSystem : AbstractSystem
{
    private GameObject cameras;

    private CinemachineVirtualCamera staticCamera;
    private CinemachineVirtualCamera selectingCamera;
    private CinemachineVirtualCamera followCamera;

    public CameraSystem() { }

    protected override void OnInit()
    {
        base.OnInit();

        cameras = GameObject.Find("Cameras");
        staticCamera = UnityTools.Instance.GetComponentFromChildren<CinemachineVirtualCamera>(cameras, "StaticCamera");
        selectingCamera = UnityTools.Instance.GetComponentFromChildren<CinemachineVirtualCamera>(cameras, "SelectingCamera");
        followCamera = UnityTools.Instance.GetComponentFromChildren<CinemachineVirtualCamera>(cameras, "FollowCamera");
    }

    public void SetCameraTarget(CameraType type, Transform trans)
    {
        switch (type)
        {
            case CameraType.staticCamera:
                staticCamera.Follow = trans;
                break;
            case CameraType.selectingCamera:
                selectingCamera.Follow = trans;
                break;
            case CameraType.followCamera:
                followCamera.Follow = trans;
                break;
        }
    }

    // NOTE:每次调用完，记得同时调用SetCameraTarget，因为每一个相机的target不一样
    public void SwitchCamera(CameraType type)
    {
        switch (type)
        {
            case CameraType.staticCamera:
                staticCamera.gameObject.SetActive(true);
                selectingCamera.gameObject.SetActive(false);
                followCamera.gameObject.SetActive(false);
                break;
            case CameraType.selectingCamera:
                staticCamera.gameObject.SetActive(false);
                selectingCamera.gameObject.SetActive(true);
                followCamera.gameObject.SetActive(false);
                break;
            case CameraType.followCamera:
                staticCamera.gameObject.SetActive(false);
                selectingCamera.gameObject.SetActive(false);
                followCamera.gameObject.SetActive(true);
                break;
        }
    }
}