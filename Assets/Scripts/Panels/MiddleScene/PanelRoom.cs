using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                collider = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f, LayerMask.GetMask("Player"));
                if (collider)
                {
                    cameraSystem.SwitchCamera(CameraType.selectingCamera);
                    cameraSystem.SetCameraTarget(CameraType.selectingCamera, collider.transform.parent);
                    EnterPanel<PanelSelectingPlayer>();
                    // HACK
                    gameObject.SetActive(false);
                }
            }

        }
    }
}
