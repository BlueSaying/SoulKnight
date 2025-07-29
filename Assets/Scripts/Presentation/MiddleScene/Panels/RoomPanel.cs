using System;
using UnityEngine;
using UnityEngine.UI;

namespace MiddleScene
{
    public class RoomPanel : Panel
    {
        private Button UIbackButton;
        private Button UIstoreButton;

        protected override void Awake()
        {
            base.Awake();

            UIbackButton = UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonBack");
            UIstoreButton = UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonStore");

            UIbackButton.onClick.AddListener(() => { SceneFacade.Instance.LoadScene(SceneName.MainMenuScene); });
            UIstoreButton.onClick.AddListener(() => { Debug.Log("打开商店"); });
        }

        protected override void Update()
        {
            base.Update();

            // 检测鼠标是否点击并点击到了玩家上
            if (SystemRepository.Instance.GetSystem<InputSystem>().GetMouseButtonDownInput(MouseInputType.leftButton))
            {
                // Physics2D.OverlapCircle(point,radius,layerMask)用于创建一个圆形区域的碰撞体
                // Camera.main.ScreenToWorldPoint()鼠标的屏幕坐标转换为游戏世界坐标系中的位置（单位：Unity单位）
                // Input.mousePosition获取鼠标在屏幕坐标系中的坐标（单位：像素，原点在左下角）。
                Collider2D _collider = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f, LayerMask.GetMask("Player"));
                if (_collider)
                {
                    // 设置相机
                    SystemRepository.Instance.GetSystem<CameraSystem>().SwitchCamera(CameraType.SelectingCamera);
                    SystemRepository.Instance.GetSystem<CameraSystem>().SetCameraTarget(CameraType.SelectingCamera, _collider.transform.parent);

                    // HACK:后期应该移动至表现层
                    GameObject selectingGameObject = _collider.transform.parent.gameObject;
                    SystemRepository.Instance.GetSystem<PlayerSystem>().SetMainPlayer(selectingGameObject);

                    UIMediator.Instance.OpenPanel(PanelName.SelectingPlayerPanel.ToString());
                    UIMediator.Instance.ClosePanel(PanelName.RoomPanel.ToString());
                }
            }
        }
    }
}