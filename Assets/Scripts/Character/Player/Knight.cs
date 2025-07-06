using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class Knight : IPlayer
{
    public Knight(GameObject obj) : base(obj) { }
    protected override void OnInit()
    {
        base.OnInit();
        _playerStateMachine.SetState<KnightIdleState>();
    }
    
}