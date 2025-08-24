
public class PlayerModel : CharacterModel
{
    public new PlayerStaticAttr staticAttr { get => base.staticAttr as PlayerStaticAttr; set => base.staticAttr = value; }
    public new PlayerDynamicAttr dynamicAttr { get => base.dynamicAttr as PlayerDynamicAttr; set => base.dynamicAttr = value; }

    public PlayerModel(PlayerStaticAttr staticAttr, PlayerDynamicAttr dynamicAttr) : base(staticAttr, dynamicAttr) { }

    public override void Recover()
    {
        base.Recover();
        dynamicAttr.curArmor.AddModifier(new FlatModifier(staticAttr.maxArmor - dynamicAttr.curArmor.Value));
        dynamicAttr.curEnergy.AddModifier(new FlatModifier(staticAttr.maxEnergy - dynamicAttr.curEnergy.Value));

        EventCenter.Instance.NotifyEvent(EventType.UpdateBattlePanel);
    }
}