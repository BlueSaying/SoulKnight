using System;
using System.Collections.Generic;
using UnityEngine;

public enum MouseInputType
{
    leftButton,
    rightButton,
    middleButton,
}

/// <summary>
/// 键盘输入之类型之枚举
/// </summary>
public enum KeyInputType
{
    /// <summary>
    /// 上移
    /// </summary>
    upward,

    /// <summary>
    /// 下移
    /// </summary>
    downward,

    /// <summary>
    /// 左移
    /// </summary>
    leftwark,

    /// <summary>
    /// 右移
    /// </summary>
    rightwark,

    /// <summary>
    /// 玩家拾取物品
    /// </summary>
    pickUp,

    /// <summary>
    /// 玩家切换武器
    /// </summary>
    switchWeapon,

    /// <summary>
    /// 玩家释放技能
    /// </summary>
    releaseSkill,

    /// <summary>
    /// 玩家射击
    /// </summary>
    shoot,
}

public class InputSystem : BaseSystem
{
    // 储存按键设置
    private Dictionary<KeyInputType, KeyCode> inputDic;

    public InputSystem()
    {
        inputDic = new Dictionary<KeyInputType, KeyCode>();

        // NOTE:默认按键设置
        // OPTIMIZE:实现玩家自定义按键
        inputDic[KeyInputType.upward] = KeyCode.W;
        inputDic[KeyInputType.downward] = KeyCode.S;
        inputDic[KeyInputType.leftwark] = KeyCode.A;
        inputDic[KeyInputType.rightwark] = KeyCode.D;
        inputDic[KeyInputType.pickUp] = KeyCode.F;
        inputDic[KeyInputType.switchWeapon] = KeyCode.R;
        inputDic[KeyInputType.shoot] = KeyCode.J;
        inputDic[KeyInputType.releaseSkill] = KeyCode.Space;
    }

    public Vector2 GetMoveInput()
    {
        Vector2 dir = Vector2.zero;
        if (GetKeyInput(KeyInputType.upward)) dir += Vector2.up;
        if (GetKeyInput(KeyInputType.downward)) dir += Vector2.down;
        if (GetKeyInput(KeyInputType.leftwark)) dir += Vector2.left;
        if (GetKeyInput(KeyInputType.rightwark)) dir += Vector2.right;
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
}