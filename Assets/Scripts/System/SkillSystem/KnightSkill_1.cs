// 骑士1技能,火力全开
// 短时间内双持当前武器进行攻击
using UnityEngine;

public class KnightSkill_1 : Skill
{
    // 技能持续时间
    private float skillTimer;
    private const float SkillTime = 5f;

    // 技能冷却时间
    private float coolTimer;
    private const float CoolTime = 10f;

    // 当前技能是否已释放
    private bool isSkillRealease;

    private static readonly string SkillName = "火力全开";
    private static readonly string SkillDescription = "短时间内双持当前武器进行攻击";
    private static readonly string SkillDetail = "击败敌人增加技能持续时间\n技能冷却：10秒";

    // 第二把枪
    private Weapon secondWeapon;

    public KnightSkill_1(Player owner) : base(owner)
    {
        coolTimer = 10f;
    }

    public override void RealeaseSkill()
    {
        if (owner.usingWeapon == null || coolTimer < CoolTime || isSkillRealease) return;

        base.RealeaseSkill();

        isSkillRealease = true;
        skillTimer = 0f;

        // 播放技能动画
        owner.skillOriginPoint.SetActive(true);

        WeaponModel model = SystemRepository.Instance.GetSystem<WeaponSystem>().GetWeaponModel(owner.usingWeapon.WeaponType);
        secondWeapon = WeaponFactory.GetWeapon(model, owner);
        secondWeapon.transform.localPosition += new Vector3(0.75f, 0);
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        if (secondWeapon != null)
        {
            secondWeapon.OnFixedUpdate();
        }
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (secondWeapon != null)
        {
            secondWeapon.OnUpdate();
            secondWeapon.ControlWeapon(SystemRepository.Instance.GetSystem<InputSystem>().GetKeyInput(KeyInputType.Shoot));
            
            // 尝试自动瞄准最近敌人
            TryAutoAimingEnemy();
        }

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

    // 获取自动瞄准的敌人
    public void TryAutoAimingEnemy()
    {
        // 仅10米内的敌人可以自动瞄准
        const float AutoAimingDistance = 10f;

        Enemy cloestEnemy = null;
        float distance = AutoAimingDistance * AutoAimingDistance;

        // 遍历所有敌人
        foreach (var enemy in SystemRepository.Instance.GetSystem<EnemySystem>().enemies)
        {
            if (enemy.isDead) continue;

            float x = (enemy.transform.position.x - owner.transform.position.x);
            float y = (enemy.transform.position.y - owner.transform.position.y);

            if (x * x + y * y < distance)
            {
                cloestEnemy = enemy;
                distance = x * x + y * y;
            }
        }

        if (cloestEnemy == null)
        {
            secondWeapon.RotateWeapon(SystemRepository.Instance.GetSystem<InputSystem>().GetMoveInput());
        }
        else
        {
            Vector2 dir = (cloestEnemy.transform.position - owner.transform.position).normalized;
            secondWeapon.RotateWeapon(dir);
        }
    }

    public void EndSkill()
    {
        // 停止技能动画
        owner.skillOriginPoint.SetActive(false);

        Object.Destroy(secondWeapon.gameObject);
        secondWeapon = null;
        coolTimer = 0f;
        isSkillRealease = false;
    }
}