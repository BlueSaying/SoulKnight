using System.Collections.Generic;
using UnityEngine;

public class IPlayer : ICharacter
{
    public new PlayerDynamicAttr dynamicAttr { get => base.dynamicAttr as PlayerDynamicAttr; set => base.dynamicAttr = value; }

    protected Animator animator;
    protected PlayerStateMachine _playerStateMachine;

    protected List<IPlayerWeapon> weapons;
    protected IPlayerWeapon usingWeapon;

    public IPlayer(GameObject obj) : base(obj) { }

    protected override void OnInit()
    {
        base.OnInit();
        _playerStateMachine = new PlayerStateMachine(this);
        weapons = new List<IPlayerWeapon>();
        animator = transform.Find("Sprite").GetComponent<Animator>();
    }
    protected override void OnCharacterUpdate()
    {
        base.OnCharacterUpdate();
        _playerStateMachine.GameUpdate();

        if (usingWeapon != null)
        {
            usingWeapon.GameUpdate();
            usingWeapon.ControlWeapon(Input.GetKeyDown(KeyCode.J));
            usingWeapon.RotateWeapon(GameMediator.Instance.GetController<InputController>().GetMovementInput());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SwitchWeapon();
        }

        //Debug.Log("当前武器数量"+weapons.Count);
    }

    public void AddWeapon(PlayerWeaponType type)
    {
        IPlayerWeapon newWeapon = WeaponFactory.Instance.GetPlayerWeapon(type, this);

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

        foreach (IPlayerWeapon weapon in weapons)
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

    public void UseWeapon(IPlayerWeapon weapon)
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

    public IPlayerWeapon GetUsingWeapon()
    {
        return usingWeapon;
    }
}