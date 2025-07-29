using UnityEngine;

namespace MiddleScene
{
    public class BattlePanel : Panel
    {
        protected override void Awake()
        {
            base.Awake();

            SystemRepository.Instance.GetSystem<CameraSystem>().SwitchCamera(CameraType.followCamera);

            // 设置相机跟随目标
            Transform mainPlayerTransform = SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer.transform;
            SystemRepository.Instance.GetSystem<CameraSystem>().SetCameraTarget(CameraType.followCamera, mainPlayerTransform);
        }
    }
}