using UnityEngine;

public class IPlayer : ICharacter
{
    protected Animator animator;
    protected PlayerStateMachine _playerStateMachine;

    protected IPlayerWeapon weapon;

    public PlayerInput playerInput { get; protected set; }

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

        if (weapon != null)
        {
            weapon.GameUpdate();
            weapon.ControlWeapon(Input.GetKeyDown(KeyCode.J));
            weapon.RotateWeapon(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }
    }
    public void AddWeapon(PlayerWeaponType type)
    {
        weapon = WeaponFactory.Instance.GetPlayerWeapon(type, this);
    }

    public void SetPlayerInput(PlayerInput playerInput)
    {
        this.playerInput = playerInput;
    }
}