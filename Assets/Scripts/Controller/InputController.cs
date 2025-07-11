using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家所有输入类型之枚举
/// </summary>
public enum KeyInputType
{
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
}

public class InputController : AbstractController
{
    // 储存按键设置
    private Dictionary<KeyInputType, KeyCode> inputDic;

    public InputController()
    {
        inputDic = new Dictionary<KeyInputType, KeyCode>();

        // NOTE:默认按键设置
        // OPTIMIZE:实现玩家自定义按键
        inputDic[KeyInputType.pickUp] = KeyCode.F;
        inputDic[KeyInputType.switchWeapon] = KeyCode.R;
        inputDic[KeyInputType.releaseSkill] = KeyCode.Space;
    }

    protected override void OnInit()
    {
        base.OnInit();
    }

    protected override void AlwaysUpdate()
    {
        base.AlwaysUpdate();
    }

    public Vector2 GetMovementInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public bool GetKeyInput(KeyInputType type)
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