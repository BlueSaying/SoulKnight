using System;
using UnityEngine;

namespace MiddleScene
{
    public class PanelRoom : IPanel
    {
        private CameraSystem cameraSystem;
        private Collider2D collider;

        public PanelRoom(IPanel parent) : base(parent)
        {
            children.Add(new PanelSelectingPlayer(this));
        }

        protected override void OnInit()
        {
            base.OnInit();
            cameraSystem = GameMediator.Instance.GetSystem<CameraSystem>();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            // 检测鼠标是否点击并点击到了玩家上
            if (Input.GetMouseButton(0))
            {
                // Physics2D.OverlapCircle(point,radius,layerMask)用于创建一个圆形区域的碰撞体
                // Camera.main.ScreenToWorldPoint()鼠标的屏幕坐标转换为游戏世界坐标系中的位置（单位：Unity单位）
                // Input.mousePosition获取鼠标在屏幕坐标系中的坐标（单位：像素，原点在左下角）。
                collider = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f, LayerMask.GetMask("Player"));
                if (collider)
                {
                    cameraSystem.SwitchCamera(CameraType.selectingCamera);
                    cameraSystem.SetCameraTarget(CameraType.selectingCamera, collider.transform.parent);
                    EnterPanel<PanelSelectingPlayer>();

                    // HACK:点击角色后将原本的UI隐藏
                    gameObject.SetActive(false);
                }
            }

        }
    }
}
