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

        AudioManager.Instance.PlaySound(AudioType.gun, AudioName.fx_gun_6);
        
        Quaternion quaternion = rotation * Quaternion.Euler(0, 0, UnityTools.GetRandomFloat(-model.staticAttr.scatterRate / 2.0f, model.staticAttr.scatterRate / 2.0f));
        ItemFactory.Instance.CreateBullet(BulletType.BulletBasketball, shootPoint.transform.position, quaternion, owner, model.staticAttr.damage);
    }
}

