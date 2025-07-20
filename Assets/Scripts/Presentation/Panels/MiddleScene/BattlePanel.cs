using UnityEngine;

namespace MiddleScene
{
    public class BattlePanel : Panel
    {
        protected override void Awake()
        {
            base.Awake();

            GameMediator.Instance.GetSystem<CameraSystem>().SwitchCamera(CameraType.followCamera);

            // 设置相机跟随目标
            GameMediator.Instance.GetSystem<CameraSystem>()
                .SetCameraTarget(CameraType.followCamera, GameMediator.Instance.GetSystem<PlayerSystem>().mainPlayer.transform);
        }
    }
}