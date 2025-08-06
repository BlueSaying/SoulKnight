using UnityEngine;
using UnityEngine.UI;

public class BattlePanel : Panel
{
    private PlayerModel playerModel;

    protected override void Awake()
    {
        base.Awake();

        playerModel = SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer.model;
        RefreshPlayerStatePanel();

        EventCenter.Instance.RegisterEvent(EventType.UpdateBattlePanel, RefreshPlayerStatePanel);
    }

    private void RefreshPlayerStatePanel()
    {
        // fresh HP state
        Transform sliderHP = UnityTools.Instance.GetTransformFromChildren(gameObject, "SliderHP");
        sliderHP.GetComponent<Slider>().value = 1.0f * playerModel.dynamicAttr.curHP / playerModel.staticAttr.maxHP;
        sliderHP.Find("Text").GetComponent<Text>().text = playerModel.dynamicAttr.curHP + "/" + playerModel.staticAttr.maxHP;

        // fresh armor
        Transform sliderArmor = UnityTools.Instance.GetTransformFromChildren(gameObject, "SliderArmor");
        sliderArmor.GetComponent<Slider>().value = 1.0f * playerModel.dynamicAttr.curHP / playerModel.staticAttr.maxHP;
        sliderArmor.Find("Text").GetComponent<Text>().text = playerModel.dynamicAttr.curHP + "/" + playerModel.staticAttr.maxHP;

        // fresh energy
        Transform sliderEnergy = UnityTools.Instance.GetTransformFromChildren(gameObject, "SliderEnergy");
        sliderEnergy.GetComponent<Slider>().value = 1.0f * playerModel.dynamicAttr.curHP / playerModel.staticAttr.maxHP;
        sliderEnergy.Find("Text").GetComponent<Text>().text = playerModel.dynamicAttr.curHP + "/" + playerModel.staticAttr.maxHP;
    }
}