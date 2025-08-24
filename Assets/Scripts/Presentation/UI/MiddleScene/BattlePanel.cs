using UnityEngine;
using UnityEngine.UI;

namespace MiddleScene
{
    public class BattlePanel : Panel
    {
        private Player player;

        protected override void Awake()
        {
            base.Awake();

            SystemRepository.Instance.GetSystem<CameraSystem>().SwitchCamera(CameraType.FollowCamera);

            // 设置相机跟随目标
            Transform mainPlayerTransform = SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer.transform;
            SystemRepository.Instance.GetSystem<CameraSystem>().SetCameraTarget(CameraType.FollowCamera, mainPlayerTransform);

            player = SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer;
            RefreshPanel();

            EventCenter.Instance.RegisterEvent(EventType.UpdateBattlePanel, RefreshPanel);
        }

        private void RefreshPanel()
        {
            // fresh HP state
            Transform sliderHP = UnityTools.Instance.GetTransformFromChildren(gameObject, "SliderHP");
            sliderHP.GetComponent<Slider>().value = 1.0f * player.CurHP / player.maxHP;
            sliderHP.Find("Text").GetComponent<Text>().text = player.CurHP + " / " + player.maxHP;

            // fresh armor
            Transform sliderArmor = UnityTools.Instance.GetTransformFromChildren(gameObject, "SliderArmor");
            sliderArmor.GetComponent<Slider>().value = 1.0f * player.CurArmor / player.maxArmor;
            sliderArmor.Find("Text").GetComponent<Text>().text = player.CurArmor + " / " + player.maxArmor;

            // fresh energy
            Transform sliderEnergy = UnityTools.Instance.GetTransformFromChildren(gameObject, "SliderEnergy");
            sliderEnergy.GetComponent<Slider>().value = 1.0f * player.CurEnergy / player.maxEnergy;
            sliderEnergy.Find("Text").GetComponent<Text>().text = player.CurEnergy + " / " + player.maxEnergy;
        }
    }
}