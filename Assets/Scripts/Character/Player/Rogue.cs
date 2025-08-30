using UnityEngine;

public class Rogue : Player
{
    public Rogue(GameObject obj, PlayerModel playerModel, Skill skill) : base(obj, playerModel, skill) { }

    protected override void OnEnter()
    {
        base.OnEnter();
        stateMachine = new RogueFSM(this);
        skill = new RogueSkill_1(this);

        // 根据皮肤播放音效
        if (PlayerSkinType == PlayerSkinType.RogueKun)
        {
            AudioManager.Instance.PlaySound(AudioType.Others, AudioName.quanminzhizuorenmen);
        }
    }
}