using UnityEngine;

public class SliverCoin : Dropped
{
    public SliverCoin(GameObject gameObject) : base(gameObject) { }

    protected override float PickUpDistance { get => 6.5f; }

    protected override void OnHitPlayer(Player player)
    {
        base.OnHitPlayer(player);

        int gold = 3;
        SystemRepository.Instance.GetSystem<GlobalSystem>().Gold += gold;
    }
}