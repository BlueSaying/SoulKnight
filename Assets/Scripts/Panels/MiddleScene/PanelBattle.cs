using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MiddleScene
{
    public class PanelBattle : Panel
    {
        public PanelBattle(Panel parent) : base(parent) { }

        protected override void OnEnter()
        {
            base.OnEnter();
            GameMediator.Instance.GetSystem<CameraSystem>().SwitchCamera(CameraType.followCamera);

            // 设置相机跟随目标
            GameMediator.Instance.GetSystem<CameraSystem>()
                .SetCameraTarget(CameraType.followCamera, GameMediator.Instance.GetController<PlayerController>().mainPlayer.transform);

        }
    }
}
