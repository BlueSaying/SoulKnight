using UnityEngine;

public class PlayerInput
{
    public float hor, ver;
    public Vector2 weaponDir;
    public bool isAttack;
}

public class InputController : AbstractController
{
    public PlayerInput input { get; protected set; }

    private Vector2 dir;

    protected override void OnInit()
    {
        base.OnInit();
        input = new PlayerInput();
    }

    protected override void AlwaysUpdate()
    {
        base.AlwaysUpdate();
        input.hor = Input.GetAxisRaw("Horizontal");
        input.ver = Input.GetAxisRaw("Vertical");

        dir.Set(input.hor, input.ver);
        if (dir.magnitude != 0)
        {
            input.weaponDir = dir;
        }
    }
}