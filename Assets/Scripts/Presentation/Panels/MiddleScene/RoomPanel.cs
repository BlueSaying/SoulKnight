using System;
using UnityEngine;
using UnityEngine.UI;

namespace MiddleScene
{
    public class RoomPanel : Panel
    {
        private Collider2D _collider;

        protected override void Awake()
        {
            base.Awake();

            UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonBack")
                .onClick.AddListener(() => { SceneCommand.Instance.LoadScene(SceneName.MainMenuScene); });
            UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonStore")
                .onClick.AddListener(() => { Debug.Log("打开商店"); });

            
        }

        protected override void Update()
        {
            base.Update();

            // 检测鼠标是否点击并点击到了玩家上
            if (Input.GetMouseButton(0))
            {
                // Physics2D.OverlapCircle(point,radius,layerMask)用于创建一个圆形区域的碰撞体
                // Camera.main.ScreenToWorldPoint()鼠标的屏幕坐标转换为游戏世界坐标系中的位置（单位：Unity单位）
                // Input.mousePosition获取鼠标在屏幕坐标系中的坐标（单位：像素，原点在左下角）。
                _collider = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f, LayerMask.GetMask("Player"));
                if (_collider)
                {
                    // 设置相机
                    GameMediator.Instance.GetSystem<CameraSystem>().SwitchCamera(CameraType.selectingCamera);
                    GameMediator.Instance.GetSystem<CameraSystem>().SetCameraTarget(CameraType.selectingCamera, _collider.transform.parent);

                    GameMediator.Instance.GetSystem<PlayerSystem>().SetMainPlayerType(_collider.transform.parent.gameObject);
                    UIManager.Instance.OpenPanel(PanelName.SelectingPlayerPanel.ToString());
                    UIManager.Instance.ClosePanel(PanelName.RoomPanel.ToString());
                }
            }
        }
    }
}
