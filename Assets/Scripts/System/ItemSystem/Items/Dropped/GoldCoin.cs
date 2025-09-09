using UnityEngine;

public class GoldCoin : Dropped
{
    public GoldCoin(GameObject gameObject) : base(gameObject) { }

    protected override float PickUpDistance   { get => 6.5f; }

    protected override void OnHitPlayer(Player player)
    {
        base.OnHitPlayer(player);

        int gold = 5;
        SystemRepository.Instance.GetSystem<GlobalSystem>().Gold += gold;
    }
}