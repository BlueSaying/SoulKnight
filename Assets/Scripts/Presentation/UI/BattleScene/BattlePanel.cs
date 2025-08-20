using UnityEngine;
using UnityEngine.UI;

namespace BattleScene
{
    public class BattlePanel : Panel
    {
        private PlayerModel playerModel;

        protected override void Start()
        {
            base.Start();
            playerModel = SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer.model;
            RefreshPanel();

            EventCenter.Instance.RegisterEvent(EventType.UpdateBattlePanel, RefreshPanel);
        }

        private void RefreshPanel()
        {
            // fresh HP state
            Transform sliderHP = UnityTools.Instance.GetTransformFromChildren(gameObject, "SliderHP");
            sliderHP.GetComponent<Slider>().value = 1.0f * playerModel.dynamicAttr.curHP / playerModel.staticAttr.maxHP;
            sliderHP.Find("Text").GetComponent<Text>().text = playerModel.dynamicAttr.curHP + " / " + playerModel.staticAttr.maxHP;

            // fresh armor
            Transform sliderArmor = UnityTools.Instance.GetTransformFromChildren(gameObject, "SliderArmor");
            sliderArmor.GetComponent<Slider>().value = 1.0f * playerModel.dynamicAttr.curArmor / playerModel.staticAttr.maxArmor;
            sliderArmor.Find("Text").GetComponent<Text>().text = playerModel.dynamicAttr.curArmor + " / " + playerModel.staticAttr.maxArmor;

            // fresh energy
            Transform sliderEnergy = UnityTools.Instance.GetTransformFromChildren(gameObject, "SliderEnergy");
            sliderEnergy.GetComponent<Slider>().value = 1.0f * playerModel.dynamicAttr.curEnergy / playerModel.staticAttr.maxEnergy;
            sliderEnergy.Find("Text").GetComponent<Text>().text = playerModel.dynamicAttr.curEnergy + " / " + playerModel.staticAttr.maxEnergy;
        }
    }
}