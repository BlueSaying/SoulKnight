using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : AbstractSystem
{
    public GameObject playerGameObject;
    public Player mainPlayer { get; protected set; }
    private List<Pet> pets;

    public PlayerSystem() { }

    protected override void OnInit()
    {
        base.OnInit();
        pets = new List<Pet>();

        EventCenter.Instance.ReigisterEvent(EventType.OnSelectSkinComplete, false, () =>
        {
            mainPlayer = PlayerFactory.Instance.CreatePlayer(Enum.Parse<PlayerType>(playerGameObject.name));
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

    public void SetMainPlayerType(GameObject selectingGameObject)
    {
        this.playerGameObject = selectingGameObject;
    }

    public void AddPlayerPet(PetType type, Player owner)
    {
        pets.Add(PetFactory.Instance.CreatePet(type, owner, new Vector2(-1, -2), Quaternion.identity));
    }
}