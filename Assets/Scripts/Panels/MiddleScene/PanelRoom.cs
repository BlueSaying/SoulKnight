using System;
using UnityEngine;

namespace MiddleScene
{
    public class PanelRoom : IPanel
    {
        private Collider2D collider;

        public PanelRoom(IPanel parent) : base(parent)
        {
            children.Add(new PanelSelectingPlayer(this));
        }

        protected override void OnInit()
        {
            base.OnInit();
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            GameMediator.Instance.GetSystem<CameraSystem>().SwitchCamera(CameraType.staticCamera);
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
                    GameMediator.Instance.GetSystem<CameraSystem>().SwitchCamera(CameraType.selectingCamera);
                    GameMediator.Instance.GetSystem<CameraSystem>().SetCameraTarget(CameraType.selectingCamera, collider.transform.parent);
                    GetPanel<PanelSelectingPlayer>().SetSelectingPlayer(collider.transform.parent.gameObject);
                    EnterPanel<PanelSelectingPlayer>();

                    // HACK:点击角色后将原本的UI隐藏
                    panel.SetActive(false);
                }
            }

        }
    }
}
