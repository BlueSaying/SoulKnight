#region 通用场景
/// <summary>
/// 系统分类
/// </summary>
public enum SystemType
{
    BuffSystem,

    CameraSystem,

    EnemySystem,

    InputSystem,

    ItemSystem,

    MapSystem,

    PlayerSystem,

    WeaponSystem,
}

/// <summary>
/// 武器大类
/// </summary>
public enum WeaponCategory
{
    Bow,

    CloseCombat,

    Melee,

    Missile,

    Other,

    Rifle,

    Shotgun,

    Staff,

    ThrownWeapon,

    Pistol,


}

/// <summary>
/// 武器品质
/// </summary>
public enum QualityType
{
    Blue,

    Green,

    Orange,

    Purple,

    Red,

    colorful,

    White,


}

/// <summary>
/// 玩家武器类型
/// </summary>
public enum WeaponType
{
    Ak47,

    AssaultRifle,

    BadPistol,

    Basketball,

    Blowpipe,

    BlueFireGatling,

    Bow,

    CrimsonWineGlass,

    DesertEagle,

    DormantBubbleMachine,

    DoubleBladeSword,

    EagleOfIceAndFire,

    Furnace,

    GatlingGun,

    GoblinMagicStaff,

    GrenadePistol,

    H2O,

    Hammer,

    Handgun,

    Hoe,

    Icebreaker,

    MissileBattery,

    NextNextNextGenSMG,

    P250Pistol,

    PKP,

    Pike,

    RainbowGatling,

    Shotgun,

    Shower,

    SnowFoxL,

    TheCode,

    TheCodePlus,

    TrumpetFlower,

    UZI,

    WoodenCross,

}

/// <summary>
/// 关卡大章
/// </summary>
public enum LevelType
{
    Forest,
}

/// <summary>
/// 地牢房间类型
/// </summary>
public enum RoomType
{
    Birth,

    Boss,

    Chest,

    Corridor,

    Normal,

    Speical,

    Transmission,

    Empty,


}

/// <summary>
/// 鼠标输入枚举
/// </summary>
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
    UpWard,

    /// <summary>
    /// 下移
    /// </summary>
    DownWard,

    /// <summary>
    /// 左移
    /// </summary>
    LeftWard,

    /// <summary>
    /// 右移
    /// </summary>
    RightWard,

    /// <summary>
    /// 玩家拾取物品
    /// </summary>
    PickUp,

    /// <summary>
    /// 玩家释放技能
    /// </summary>
    ReleaseSkill,

    /// <summary>
    /// 玩家射击
    /// </summary>
    Shoot,

    /// <summary>
    /// 玩家切换武器
    /// </summary>
    SwitchWeapon,


}

/// <summary>
/// Buff类型
/// </summary>
public enum BuffType
{
    Burn,

    Freeze,

    Poisoning,

    None,


}

/// <summary>
/// 触发事件类型
/// </summary>
public enum TriggerEventType
{
    OnTriggerEnter2D,
    OnTriggerExit2D,
    OnTriggerStay2D,
}

/// <summary>
/// 音频类型
/// </summary>
public enum AudioType
{
    gun,
}

/// <summary>
/// 音频名称
/// </summary>
public enum AudioName
{
    /// <summary>
    /// 手枪开火
    /// </summary>
    fx_gun_1,
}

/// <summary>
/// 寻路节点类型
/// </summary>
public enum NodeType
{
    None,

    Obstacle,
}

/// <summary>
/// 事件类型
/// </summary>
public enum EventType
{
    #region 永久事件
    /// <summary>
    /// 场景开始切换
    /// </summary>
    OnSceneSwitchStart,

    /// <summary>
    /// 场景完成切换
    /// </summary>
    OnSceneSwitchComplete,
    #endregion

    /// <summary>
    /// 是否为永久事件分界点
    /// </summary>
    isPermanentPoint,

    #region 非永久事件
    /// <summary>
    /// 战斗结束
    /// </summary>
    OnBattleFinish,

    /// <summary>
    /// 敌人死亡
    /// </summary>
    OnEnemyDie,

    /// <summary>
    /// 房间生成完毕
    /// </summary>
    OnFinishRoomCreate,

    /// <summary>
    /// 玩家死亡
    /// </summary>
    OnPlayerDie,

    /// <summary>
    /// 角色选择完毕
    /// </summary>
    OnSelectPlayerComplete,

    /// <summary>
    /// 皮肤选择完毕
    /// </summary>
    OnSelectSkinComplete,

    /// <summary>
    /// 更新战斗界面
    /// </summary>
    UpdateBattlePanel,


    #endregion
}

/// <summary>
/// 玩家类型
/// </summary>
public enum PlayerType
{
    Knight,

    Rogue,
}

/// <summary>
/// 玩家皮肤类型
/// </summary>
public enum PlayerSkinType
{
    Knight,

    Rogue,

    RogueKun,

    None,


}

/// <summary>
/// 宠物类型
/// </summary>
public enum PetType
{
    LittleCool,

}

/// <summary>
/// 子弹类型
/// </summary>
public enum BulletType
{
    Bullet_5,

    Bullet_34,
}

/// <summary>
/// 特效类型
/// </summary>
public enum EffectType
{
    /// <summary>
    /// 敌人出现
    /// </summary>
    AppearEffect,

    /// <summary>
    /// 子弹碰撞
    /// </summary>
    BoomEffect,

    /// <summary>
    /// 敌人生成
    /// </summary>
    SummonEffect,


}

/// <summary>
/// 场景名称
/// </summary>
public enum SceneName
{
    /// <summary>
    /// 主菜单
    /// </summary>
    MainMenuScene,

    /// <summary>
    /// 大厅
    /// </summary>
    MiddleScene,

    /// <summary>
    /// 战斗场景
    /// </summary>
    BattleScene,
}

/// <summary>
/// 敌人类型
/// </summary>
public enum EnemyType
{
    DireBoar,

    EliteGoblinGuard,

    GoblinGiant,

    GoblinGuard,

    GoblinShaman,

    GunShark,

    Stake,

    TrumpetFlower,

    Boar,


}
#endregion

#region MainMenuScene
namespace MainMenuScene
{
    public enum CameraType
    {

    }

    public enum PanelName
    {
        MainMenuPanel,

        KeyBoardPanel,
    }
}
#endregion

#region MiddleScene
namespace MiddleScene
{
    public enum CameraType
    {
        /// <summary>
        /// 角色选择完成后，始终跟随角色的相机
        /// </summary>
        FollowCamera,

        /// <summary>
        /// 选中某个角色后，对该角色特写的相机
        /// </summary>
        SelectingCamera,

        /// <summary>
        /// 刚进游戏时，选择角色时的相机
        /// </summary>
        StaticCamera,


    }

    public enum PanelName
    {
        GemPanel,

        RoomPanel,

        SelectingPlayerPanel,

        SelectingSkinPanel,

        BattlePanel,


    }
}
#endregion

#region BattleScene
namespace BattleScene
{
    public enum CameraType
    {
        /// <summary>
        /// 跟随玩家的摄像机
        /// </summary>
        FollowCamera,
    }

    public enum PanelName
    {

    }
}
#endregion