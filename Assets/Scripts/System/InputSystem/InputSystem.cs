using System;
using System.Collections.Generic;
using UnityEngine;



public class InputSystem : BaseSystem
{
    // 储存按键设置
    public Dictionary<KeyInputType, KeyCode> inputDic { get; private set; }

    public InputSystem()
    {
        inputDic = new Dictionary<KeyInputType, KeyCode>();

        SetDefault();
    }    

    public Vector2 GetMoveInput()
    {
        Vector2 dir = Vector2.zero;
        if (GetKeyInput(KeyInputType.UpWard)) dir += Vector2.up;
        if (GetKeyInput(KeyInputType.DownWard)) dir += Vector2.down;
        if (GetKeyInput(KeyInputType.LeftWard)) dir += Vector2.left;
        if (GetKeyInput(KeyInputType.RightWard)) dir += Vector2.right;
        return dir.normalized;
    }

    public bool GetKeyInput(KeyInputType type)
    {
        try
        {
            return Input.GetKey(inputDic[type]);
        }
        catch (System.ArgumentOutOfRangeException)
        {
            throw new System.Exception("未储存关于" + type.ToString() + "相应键值对");
        }
    }

    public bool GetKeyDownInput(KeyInputType type)
    {
        try
        {
            return Input.GetKeyDown(inputDic[type]);
        }
        catch (System.ArgumentOutOfRangeException)
        {
            throw new System.Exception("未储存关于" + type.ToString() + "相应键值对");
        }
    }

    public bool GetKeyUpInput(KeyInputType type)
    {
        try
        {
            return Input.GetKeyUp(inputDic[type]);
        }
        catch (System.ArgumentOutOfRangeException)
        {
            throw new System.Exception("未储存关于" + type.ToString() + "相应键值对");
        }
    }

    public bool GetMouseButtonInput(MouseInputType type)
    {
        return Input.GetMouseButton((int)type);
    }

    public bool GetMouseButtonDownInput(MouseInputType type)
    {
        return Input.GetMouseButtonDown((int)type);
    }

    public bool GetMouseButtonUpInput(MouseInputType type)
    {
        return Input.GetMouseButtonUp((int)type);
    }

    // 改变键位设置
    public bool ChangeKeyCode(KeyInputType inputType, KeyCode keyCode)
    {
        if (inputDic[inputType] == keyCode)
        {
            inputDic[inputType] = keyCode;
            return false;
        }

        inputDic[inputType] = keyCode;
        return true;
    }

    // 将按键更改为默认设置
    public void SetDefault()
    {
        inputDic[KeyInputType.UpWard] = KeyCode.W;
        inputDic[KeyInputType.DownWard] = KeyCode.S;
        inputDic[KeyInputType.LeftWard] = KeyCode.A;
        inputDic[KeyInputType.RightWard] = KeyCode.D;
        inputDic[KeyInputType.PickUp] = KeyCode.F;
        inputDic[KeyInputType.SwitchWeapon] = KeyCode.R;
        inputDic[KeyInputType.Shoot] = KeyCode.J;
        inputDic[KeyInputType.ReleaseSkill] = KeyCode.Space;
    }
}