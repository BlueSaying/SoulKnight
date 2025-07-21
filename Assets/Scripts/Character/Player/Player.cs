using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IDamageable
{
    public new  PlayerModel model { get => base.model as PlayerModel; set => base.model = value; }

    protected PlayerStateMachine stateMachine;

    protected List<PlayerWeapon> weapons;
    protected PlayerWeapon usingWeapon;

    public Player(GameObject obj, PlayerModel model) : base(obj)
    {
        this.model = model;
    }

    protected override void OnInit()
    {
        base.OnInit();

        weapons = new List<PlayerWeapon>();

        // NOTE:角色初始化时，添加阿凉为宠物
        GameMediator.Instance.GetSystem<PlayerSystem>().AddPlayerPet(PetType.LittleCool, this);
    }

    protected override void OnCharacterUpdate()
    {
        base.OnCharacterUpdate();
        stateMachine.GameUpdate();

        if (usingWeapon != null)
        {
            usingWeapon.GameUpdate();
            usingWeapon.ControlWeapon(GameMediator.Instance.GetSystem<InputSystem>().GetKeyInput(KeyInputType.shoot));
            usingWeapon.RotateWeapon(GameMediator.Instance.GetSystem<InputSystem>().GetMoveInput());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SwitchWeapon();
        }
    }

    public void AddWeapon(PlayerWeaponModel model)
    {
        PlayerWeapon newWeapon = WeaponFactory.Instance.GetPlayerWeapon(model, this);

        if (usingWeapon != null)
        {
            UnequipWeapon();
        }

        EquipWeapon(newWeapon);
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

        UnequipWeapon();
        EquipWeapon(weapons[usingWeaponIndex]);
    }

    public void EquipWeapon(PlayerWeapon weapon)
    {
        weapon.isUsing = true;
        weapon.gameObject.SetActive(true);
        usingWeapon = weapon;
    }

    public void UnequipWeapon()
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
        Debug.Log(damage);
    }
}