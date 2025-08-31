using UnityEngine;

public class EnergyBall : Dropped
{
    public EnergyBall(GameObject gameObject) : base(gameObject) { }

    protected override float PickUpDistance { get => 6.5f; }

    protected override void OnHitPlayer(Player player)
    {
        base.OnHitPlayer(player);

        // HACK:钳制应放在属性中,而不是这里
        int energy = Random.Range(2, 9);
        player.CurEnergy.AddFlatModifier(Mathf.Min(player.maxEnergy - player.CurEnergy.Value, energy));
    }
}
