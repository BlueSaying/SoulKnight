using UnityEngine;
using UnityEngine.UI;

namespace BattleScene
{
    public class BattlePanel : Panel
    {
        private Player player;

        protected override void Start()
        {
            base.Start();
            player = SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer;
            RefreshPanel();

            EventCenter.Instance.RegisterEvent(EventType.UpdateBattlePanel, RefreshPanel);
        }

        private void RefreshPanel()
        {
            // fresh HP state
            Transform sliderHP = UnityTools.Instance.GetTransformFromChildren(gameObject, "SliderHP");
            sliderHP.GetComponent<Slider>().value = 1.0f * player.CurHP.Value / player.maxHP;
            sliderHP.Find("Text").GetComponent<Text>().text = player.CurHP.Value + " / " + player.maxHP;

            // fresh armor
            Transform sliderArmor = UnityTools.Instance.GetTransformFromChildren(gameObject, "SliderArmor");
            sliderArmor.GetComponent<Slider>().value = 1.0f * player.CurArmor.Value / player.maxArmor;
            sliderArmor.Find("Text").GetComponent<Text>().text = player.CurArmor.Value + " / " + player.maxArmor;

            // fresh energy
            Transform sliderEnergy = UnityTools.Instance.GetTransformFromChildren(gameObject, "SliderEnergy");
            sliderEnergy.GetComponent<Slider>().value = 1.0f * player.CurEnergy.Value / player.maxEnergy;
            sliderEnergy.Find("Text").GetComponent<Text>().text = player.CurEnergy.Value + " / " + player.maxEnergy;
        }
    }
}