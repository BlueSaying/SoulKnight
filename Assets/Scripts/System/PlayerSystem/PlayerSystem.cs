using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : BaseSystem
{
    private SceneName CurSceneName => SceneFacade.Instance.GetActiveSceneName();

    // 系统持有所有角色的属性仓库
    private PlayerRepository playerRepository;
    private PlayerSkinRepository skinRepository;

    public GameObject playerGameObject;
    public Player mainPlayer { get; protected set; }
    private PlayerSkinType skinType;

    private List<Pet> pets;

    public PlayerSystem() { }

    protected override void OnInit()
    {
        base.OnInit();
        pets = new List<Pet>();
        playerRepository = new PlayerRepository();
        skinRepository = new PlayerSkinRepository();
    }

    protected override void OnEnter()
    {
        base.OnEnter();

        switch (CurSceneName)
        {
            case SceneName.MainMenuScene:
                break;
            case SceneName.MiddleScene:
                EventCenter.Instance.RegisterEvent(EventType.OnSelectSkinComplete, false, OnSelectSkinComplete);
                break;
            case SceneName.BattleScene:
                // 记录信息
                PlayerType playerType = mainPlayer.model.staticAttr.playerType;
                Vector2 playerPos = RoomCreator.birthPos * RoomCreator.UnitSize;
                PlayerWeaponType usingWeaponType = default;
                List<PlayerWeaponType> weaponTypes = new List<PlayerWeaponType>();
                foreach (var weapon in mainPlayer.weapons)
                {
                    if (weapon.isUsing) usingWeaponType = weapon.model.staticAttr.playerWeaponType;
                    weaponTypes.Add(weapon.model.staticAttr.playerWeaponType);
                }

                // 实例化Player
                SetMainPlayer(PlayerFactory.Instance.InstantiatePlayer(playerType, playerPos, Quaternion.identity));

                // 设置mainPlayer
                mainPlayer = PlayerFactory.Instance.CreatePlayer(playerRepository.GetPlayerModel(Enum.Parse<PlayerType>(playerGameObject.name)));
                mainPlayer.rb.constraints = RigidbodyConstraints2D.FreezeRotation;

                // 设置角色皮肤

                playerGameObject.transform.Find("Sprite").GetComponent<Animator>().runtimeAnimatorController =
                    ResourcesLoader.Instance.LoadPlayerSkin(skinType.ToString());

                // 设置武器
                foreach (var weaponType in weaponTypes)
                {
                    // 先不添加正在使用的武器，待所有武器添加完再添加
                    if (weaponType != usingWeaponType)
                    {
                        mainPlayer.AddWeapon(SystemRepository.Instance.GetSystem<WeaponSystem>().GetPlayerWeaponModel(weaponType));
                    }
                }
                mainPlayer.AddWeapon(SystemRepository.Instance.GetSystem<WeaponSystem>().GetPlayerWeaponModel(usingWeaponType));

                // 设置相机
                SystemRepository.Instance.GetSystem<CameraSystem>().SetCameraTarget(BattleScene.CameraType.FollowCamera, mainPlayer.transform);

                break;
        }
    }

    protected override void OnExit()
    {
        base.OnExit();

        switch (CurSceneName)
        {
            case SceneName.MainMenuScene:
                break;
            case SceneName.MiddleScene:
                EventCenter.Instance.RemoveEvent(EventType.OnSelectSkinComplete, OnSelectSkinComplete);
                break;
            case SceneName.BattleScene:
                break;
        }

    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        mainPlayer?.GameUpdate();

        foreach (var pet in pets)
        {
            pet.GameUpdate();
        }
    }

    // 获取特定角色类型的所有数据
    public PlayerModel GetPlayerModel(PlayerType playerType)
    {
        return playerRepository.GetPlayerModel(playerType);
    }

    // 获取特定角色类型的所有皮肤
    public PlayerSkinModel GetPlayerSkinModel(PlayerType playerType)
    {
        return skinRepository.GetPlayerSkinModel(playerType);
    }

    public void SetMainPlayer(GameObject gameObject)
    {
        playerGameObject = gameObject;
    }

    public void SetMainPlayerSkin(PlayerSkinType skinType)
    {
        this.skinType = skinType;
        Debug.Log(this.skinType.ToString());
    }

    public void AddPlayerPet(PetType type, Player owner)
    {
        pets.Add(PetFactory.Instance.CreatePet(type, owner, new Vector2(-1, -2), Quaternion.identity));
    }

    #region 事件集
    public void OnSelectSkinComplete()
    {
        mainPlayer = PlayerFactory.Instance.CreatePlayer(playerRepository.GetPlayerModel(Enum.Parse<PlayerType>(playerGameObject.name)));
        mainPlayer.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    #endregion
}