using UnityEngine;

public class EnergyBall : Dropped
{
    private TrailRenderer trailRenderer;

    public EnergyBall(GameObject gameObject) : base(gameObject)
    {
        trailRenderer = gameObject.GetComponent<TrailRenderer>();
    }

    protected override float PickUpDistance { get => 6.5f; }

    public override void OnEnter()
    {
        base.OnEnter();
        trailRenderer.enabled = true;
    }

    protected override void OnHitPlayer(Player player)
    {
        base.OnHitPlayer(player);

        // HACK:钳制应放在属性中,而不是这里
        int energy = Random.Range(2, 9);
        player.CurEnergy.AddFlatModifier(Mathf.Min(player.maxEnergy - player.CurEnergy.Value, energy));

        // 将拖尾效果关闭
        trailRenderer.enabled = false;
    }
}
