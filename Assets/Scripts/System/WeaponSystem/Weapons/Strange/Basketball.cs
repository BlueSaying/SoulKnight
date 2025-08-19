using UnityEngine;


public class Basketball : Strange
{
    private GameObject shootPoint;

    public Basketball(GameObject gameObject, Character owner, WeaponModel model) : base(gameObject, owner, model)
    {
        canRotate = true;
    }

    protected override void OnInit()
    {
        base.OnInit();
        shootPoint = UnityTools.Instance.GetTransformFromChildren(gameObject, "ShootPoint").gameObject;
    }

    protected override void OnEnter()
    {
        base.OnEnter();
        
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (SystemRepository.Instance.GetSystem<InputSystem>().GetMoveInput() != Vector2.zero)
        {
            animator.SetTrigger("PlayerBasketball");
        }
    }

    protected override void OnFire()
    {
        base.OnFire();

        animator.SetTrigger("PlayerBasketball");
        //AudioManager.Instance.PlaySound(AudioType.gun, AudioName.fx_gun_1);
        ItemFactory.Instance.CreateBullet(BulletType.BulletBasketball, shootPoint.transform.position, rotOrigin.transform.rotation, owner, model.staticAttr.damage);
    }
}

