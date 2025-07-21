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
            Transform mainPlayerTransform = GameMediator.Instance.GetSystem<PlayerSystem>().mainPlayer.transform;
            GameMediator.Instance.GetSystem<CameraSystem>().SetCameraTarget(CameraType.followCamera, mainPlayerTransform);
        }
    }
}