using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class IPlayerWeapon : IWeapon
{
    public IPlayer player { get => base.character as IPlayer; set => base.character = value; }

    protected GameObject rotOrigin;

    private bool isAttackKeyDown;

    public IPlayerWeapon(GameObject gameObject, ICharacter character) : base(gameObject, character) { }

    public void ControlWeapon(bool isAttack)
    {
        if (isAttack && !isAttackKeyDown)
        {
            OnFire();
            isAttackKeyDown = true;
        }
    }

    public void RotateWeapon(Vector2 weaponDir)
    {
        if (canRotate)
        {
            float angle;
            if (character.isLeft)
            {
                angle = -Vector2.SignedAngle(Vector2.left, weaponDir);
            }
            else
            {
                angle = Vector2.SignedAngle(Vector2.right, weaponDir);
            }

            rotOrigin.transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }

    protected override void OnInit()
    {
        base.OnInit();
        rotOrigin = UnityTools.Instance.GetTransformFromChildren(gameObject, "RotOrigin").gameObject;
    }
}