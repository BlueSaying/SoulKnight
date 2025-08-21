using UnityEngine;

public class Basketball : Strange
{
    private GameObject shootPoint;

    public Basketball(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model)
    {
        canRotate = false;
    }

    protected override void OnInit()
    {
        base.OnInit();
        shootPoint = UnityTools.Instance.GetTransformFromChildren(gameObject, "ShootPoint").gameObject;
    }

    protected override void OnEnter()
    {
        base.OnEnter();

        animator.SetBool("isPickUp", isPickUp);
        #region 等待游戏物体加载的临时方案
        UnityTools.Instance.WaitThenCallFun(this, 1f, () =>
        {
            animator.SetBool("isPickUp", isPickUp);
        });
        #endregion
    }

    protected override void OnFire()
    {
        base.OnFire();

        if (owner is Player && (owner as Player).playerSkinType == PlayerSkinType.RogueKun)
        {
            AudioManager.Instance.PlaySound(AudioType.Others, AudioName.ji);
        }
        else
        {
            AudioManager.Instance.PlaySound(AudioType.Gun, AudioName.fx_gun_6);
        }

        Quaternion quaternion = rotation * Quaternion.Euler(0, 0, UnityTools.GetRandomFloat(-scatterRate / 2.0f, scatterRate / 2.0f));
        ItemFactory.Instance.CreateBullet(BulletType.BulletBasketball, shootPoint.transform.position, quaternion, owner, damage, bulletSpeed);
    }
}

