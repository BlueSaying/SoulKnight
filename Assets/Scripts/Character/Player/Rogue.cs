using UnityEngine;

public class Rogue : Player
{
    public Rogue(GameObject obj, PlayerModel playerModel) : base(obj, playerModel) { }

    protected override void OnEnter()
    {
        base.OnEnter();
        stateMachine = new RogueFSM(this);
        
        // 根据皮肤播放音效
        if(playerSkinType == PlayerSkinType.RogueKun)
        {
            AudioManager.Instance.PlaySound(AudioType.Others, AudioName.quanminzhizuorenmen);
        }
    }

}