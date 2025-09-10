#region GenericScene
/// <summary>
/// 系统分类
/// </summary>
public enum SystemType
{
    BuffSystem,

    CameraSystem,

    EnemySystem,

    GlobalSystem,

    InputSystem,

    ItemSystem,

    MapSystem,

    PlayerSystem,

    WeaponSystem,
}

/// <summary>
/// Sprite分类,用于加载Sprite
/// </summary>
public enum SpriteType
{
    Buff,

    Weapon,

    Profile,
}

/// <summary>
/// 武器大类
/// </summary>
public enum WeaponCategory
{
    Bow,

    Melee,

    //Missile,

    Rifle,

    ShotGun,

    //Staff,

    //ThrownWeapon,

    Pistol,

    Strange,
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

    //colorful,

    White,


}

/// <summary>
/// 武器类型
/// </summary>
public enum WeaponType
{
    GasBlaster,
    BadPistol,
    AK47,
    P250Pistol,
    AssaultRifle,
    DesertEagle,
    Basketball,
    StrongBow,
    CompositeBow,
    GatlingGun,
    GoblinSpear,
    StaffOfFlame,

    // ---下方为未添加武器---

    H2O,
    Furnace,
    Icebreaker,
    PKP,
    UZI,
    SnowFoxL,
    MissileBattery,
    TheCode,
    TheCodePlus,
    CrimsonWineGlass,
    GrenadePistol,
    NextNextNextGenSMG,
    EagleOfIceAndFire,
    DormantBubbleMachine,
    Shower,
    DoubleBladeSword,
    WoodenCross,
    BlueFireGatling,
    RainbowGatling,
    Handgun,
    Shotgun,
    TrumpetFlower,
    Blowpipe,
    Hoe,
    Hammer,
    GoblinMagicStaff,
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
    None,

    Burn,

    Freeze,

    Poisoning,

    Dizziness,

    Inductance,
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
/// 碰撞事件类型
/// </summary>
public enum CollisionEventType
{
    OnCollisionEnter2D,
    OnCollisionExit2D,
    OnCollisionStay2D,
}

/// <summary>
/// 音频类型
/// </summary>
public enum AudioType
{
    Bgm,

    Gun,

    Others,

    Sword,

    Hurt,
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

    /// <summary>
    /// 扔出投掷物
    /// </summary>
    fx_gun_6,

    /// <summary>
    /// 火箭与弓箭发射
    /// </summary>
    fx_gun_rocket,

    /// <summary>
    /// 开始界面BGM
    /// </summary>
    bgm_1Low,

    /// <summary>
    /// 开始大厅BGM
    /// </summary>
    bgm_room,

    /// <summary>
    /// 近战武器1
    /// </summary>
    fx_sword1,

    /// <summary>
    /// 近战武器2
    /// </summary>
    fx_sword2,

    /// <summary>
    /// 切换武器
    /// </summary>
    fx_switch,

    /// <summary>
    /// 鸡
    /// </summary>
    ji,

    /// <summary>
    /// 受击音效1
    /// </summary>
    fx_hit_p1,

    /// <summary>
    /// 受击音效2
    /// </summary>
    fx_hit_p2,

    /// <summary>
    /// 受击音效3
    /// </summary>
    fx_hit_p3,

    /// <summary>
    /// 受击音效4
    /// </summary>
    fx_hit_p4,

    /// <summary>
    /// 受击音效5
    /// </summary>
    fx_hit_p5,

    /// <summary>
    /// 受鸡音效
    /// </summary>
    niganma,

    /// <summary>
    /// 全民制作人们
    /// </summary>
    quanminzhizuorenmen
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
    /// 玩家复活
    /// </summary>
    OnPlayerRevive,

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

    Bullet_105,

    Bullet_130,

    Bullet_131,

    BulletBasketball,

    Arrow,
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

public enum DroppedType
{
    EnergyBall,
    CopperCoin,
    SliverCoin,
    GoldCoin,
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

    /// <summary>
    /// 通用场景
    /// </summary>
    Generic,
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
namespace Generic
{
    public enum PanelName
    {
        WeaponInfoPanel,

        PausePanel,
    }
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
        BattlePanel,

        RevivePanel,
    }
}
#endregion