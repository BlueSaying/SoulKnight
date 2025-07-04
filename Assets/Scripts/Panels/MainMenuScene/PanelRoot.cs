using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;


public class PanelRoot : IPanel
{
    public PanelRoot() : base(null) { }
    protected override void OnInit()
    {
        base.OnInit();
        UnityTools.Instance.GetComponentFromChildren<Button>(gameObject, "ButtonStart")
            .onClick.AddListener(() => { Debug.Log("Start Game!"); });
    }
    protected override void OnEnter()
    {
        base.OnEnter();
    }
}