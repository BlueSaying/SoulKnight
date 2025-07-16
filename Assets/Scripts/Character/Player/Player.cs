using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IDamageable
{
    public new PlayerStaticAttr staticAttr { get => base.staticAttr as PlayerStaticAttr; set => base.staticAttr = value; }
    public new PlayerDynamicAttr dynamicAttr { get => base.dynamicAttr as PlayerDynamicAttr; set => base.dynamicAttr = value; }

    protected Animator animator;
    protected PlayerStateMachine stateMachine;

    protected List<PlayerWeapon> weapons;
    protected PlayerWeapon usingWeapon;

    public Player(GameObject obj, PlayerStaticAttr staticAttr) : base(obj, staticAttr) { }

    protected override void OnInit()
    {
        base.OnInit();
        weapons = new List<PlayerWeapon>();
        animator = transform.Find("Sprite").GetComponent<Animator>();

        // NOTE:角色初始化时，添加阿凉为宠物
        GameMediator.Instance.GetController<PlayerController>().AddPlayerPet(PetType.LittleCool, this);
    }

    protected override void OnCharacterUpdate()
    {
        base.OnCharacterUpdate();
        stateMachine.GameUpdate();

        if (usingWeapon != null)
        {
            usingWeapon.GameUpdate();
            usingWeapon.ControlWeapon(GameMediator.Instance.GetController<InputController>().GetKeyInput(KeyInputType.shoot));
            usingWeapon.RotateWeapon(GameMediator.Instance.GetController<InputController>().GetMoveInput());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SwitchWeapon();
        }

        //Debug.Log("当前武器数量"+weapons.Count);
    }

    public void AddWeapon(PlayerWeaponType type)
    {
        PlayerWeapon newWeapon = WeaponFactory.Instance.GetPlayerWeapon(type, this);

        if (usingWeapon != null)
        {
            RemoveWeapon();
        }

        UseWeapon(newWeapon);
        weapons.Add(newWeapon);
    }

    // 切换下一把武器
    public void SwitchWeapon()
    {
        // 只有武器数量大于一才可以切换武器
        if (weapons.Count <= 1) return;

        int usingWeaponIndex = 0;

        foreach (PlayerWeapon weapon in weapons)
        {
            if (weapon.isUsing)
            {
                break;
            }
            usingWeaponIndex++;
        }

        usingWeaponIndex = (usingWeaponIndex + 1) % weapons.Count;

        RemoveWeapon();
        UseWeapon(weapons[usingWeaponIndex]);
    }

    public void UseWeapon(PlayerWeapon weapon)
    {
        weapon.isUsing = true;
        weapon.gameObject.SetActive(true);
        usingWeapon = weapon;
    }

    public void RemoveWeapon()
    {
        usingWeapon.isUsing = false;
        usingWeapon.OnExit();
        usingWeapon.gameObject.SetActive(false);
    }

    public PlayerWeapon GetUsingWeapon()
    {
        return usingWeapon;
    }

    public void TakeDamage(int damage)
    {
        //dynamicAttr.Hp -= damage;
        Debug.Log(dynamicAttr.Hp);
    }
}