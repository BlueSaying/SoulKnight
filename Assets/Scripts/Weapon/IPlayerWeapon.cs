using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class IPlayerWeapon : IWeapon
{
    public IPlayer player { get => base.character as IPlayer; set => base.character = value;  }
    public IPlayerWeapon(GameObject gameObject, ICharacter character) : base(gameObject, character) { }

}