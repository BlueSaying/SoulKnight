using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class IPlayer : ICharacter
{
    protected Animator animator;
    protected PlayerStateMachine _playerStateMachine;

    protected IPlayerWeapon weapon;

    public IPlayer(GameObject obj) : base(obj)
    {

    }
    protected override void OnInit()
    {
        base.OnInit();
        animator = transform.Find("Sprite").GetComponent<Animator>();
        _playerStateMachine = new PlayerStateMachine(this);
    }
    protected override void OnCharacterUpdate()
    {
        base.OnCharacterUpdate();
        _playerStateMachine.GameUpdate();
    }

    public void AddWeapon(PlayerWeaponType type)
    {
        weapon = WeaponFactory.Instance.GetPlayerWeapon(type, this);
    }
}