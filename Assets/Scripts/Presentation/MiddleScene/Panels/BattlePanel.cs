using UnityEngine;

namespace MiddleScene
{
    public class BattlePanel : Panel
    {
        protected override void Awake()
        {
            base.Awake();

            SystemRepository.Instance.GetSystem<CameraSystem>().SwitchCamera(CameraType.FollowCamera);

            // 设置相机跟随目标
            Transform mainPlayerTransform = SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer.transform;
            SystemRepository.Instance.GetSystem<CameraSystem>().SetCameraTarget(CameraType.FollowCamera, mainPlayerTransform);
        }
    }
}