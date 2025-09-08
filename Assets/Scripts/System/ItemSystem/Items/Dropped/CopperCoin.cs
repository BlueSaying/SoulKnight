using UnityEngine;

public class CopperCoin : Dropped
{
    public CopperCoin(GameObject gameObject) : base(gameObject) { }

    protected override float PickUpDistance { get => 6.5f; }

    protected override void OnHitPlayer(Player player)
    {
        base.OnHitPlayer(player);

        // HACK:钳制应放在属性中,而不是这里
        int gold = 1;
        SystemRepository.Instance.GetSystem<GlobalSystem>().Gold += gold;
    }
}