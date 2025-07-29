using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : BaseSystem
{
    // 系统持有所有角色的属性仓库
    private PlayerRepository playerRepository;
    private PlayerSkinRepository skinRepository;

    public GameObject playerGameObject;
    public Player mainPlayer { get; protected set; }
    private List<Pet> pets;

    public PlayerSystem() { }

    protected override void OnInit()
    {
        base.OnInit();
        pets = new List<Pet>();
        playerRepository = new PlayerRepository();
        skinRepository = new PlayerSkinRepository();

        EventCenter.Instance.ReigisterEvent(EventType.OnSelectSkinComplete, false, () =>
        {
            mainPlayer = PlayerFactory.Instance.CreatePlayer(playerRepository.GetPlayerModel(Enum.Parse<PlayerType>(playerGameObject.name)));
            mainPlayer.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        });
    }

    protected override void OnAfterRunUpdate()
    {
        base.OnAfterRunUpdate();

        if (mainPlayer != null)
        {
            mainPlayer.GameUpdate();
        }

        foreach (var pet in pets)
        {
            pet.GameUpdate();
        }
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

    public void AddPlayerPet(PetType type, Player owner)
    {
        pets.Add(PetFactory.Instance.CreatePet(type, owner, new Vector2(-1, -2), Quaternion.identity));
    }
}