using System.Collections;
using UnityEngine;

public class RogueSkill_1 : Skill
{
    // 技能持续时间
    private float skillTimer;
    private const float SkillTime = 0.5f;

    // 技能冷却时间
    private float coolTimer;
    private const float CoolTime = 0.05f;

    // 当前技能是否已释放
    private bool isSkillRealease;

    private static readonly string SkillName = "翻滚";
    private static readonly string SkillDescription = "向前翻滚躲开敌人子弹";
    private static readonly string SkillDetail = "翻滚后1秒内暴击率提升50%\n技能冷却：1秒";

    public RogueSkill_1(Player owner) : base(owner)
    {
        coolTimer = CoolTime;
    }

    public override void RealeaseSkill()
    {
        if (coolTimer < CoolTime || isSkillRealease) return;

        isSkillRealease = true;
        skillTimer = 0f;

        owner.Animator.SetTrigger("Roll");
        owner.isInvincible = true;

        // 释放技能
        Vector2 dir = owner.rb.velocity.normalized;

        // 如果玩家不移动
        if (dir == Vector2.zero)
        {
            float angle = owner.usingWeapon.rotation.eulerAngles.z * Mathf.Deg2Rad;
            dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            if (owner.usingWeapon.rotation.eulerAngles.y != 0) dir.x *= -1;
        }
        CoroutinePool.Instance.StartCoroutine(this, Roll(dir));
    }

    private IEnumerator Roll(Vector2 dir)
    {
        float timer = 0f;
        float time = 0.4f;

        while (true)
        {
            timer += Time.fixedDeltaTime;
            if (timer > time) break;

            MoveManager.Move(owner.rb, dir * 25f, 1000f, 800f);
            yield return new WaitForFixedUpdate();
        }
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (isSkillRealease)
        {
            skillTimer += Time.deltaTime;
            if (skillTimer >= SkillTime)
            {
                EndSkill();
            }
        }
        else coolTimer += Time.deltaTime;
    }

    public void EndSkill()
    {
        owner.isInvincible = false;

        coolTimer = 0f;
        isSkillRealease = false;
    }
}