using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class IPlayer : ICharacter
{
    protected Animator _animator;
    public IPlayer(GameObject obj) : base(obj)
    {

    }
    protected override void OnInit()
    {
        base.OnInit();
        _animator = transform.Find("Sprite").GetComponent<Animator>();
    }
}