public class GlobalSystem : BaseSystem
{
    // 金币数
    private int gold;
    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            EventCenter.Instance.NotifyEvent(EventType.UpdateBattlePanel);
        }
    }

    protected override void OnInit()
    {
        base.OnInit();

        Gold = 0;
    }
}