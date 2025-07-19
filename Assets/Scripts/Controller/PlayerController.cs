using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AbstractController
{
    public Player mainPlayer { get; protected set; }
    private List<Pet> pets;

    public PlayerController() { }

    protected override void OnInit()
    {
        base.OnInit();
        pets = new List<Pet>();
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

    public void SetMainPlayer(PlayerType playerType)
    {
        mainPlayer = PlayerFactory.Instance.CreatePlayer(playerType);
    }

    public void AddPlayerPet(PetType type, Player owner)
    {
        pets.Add(PetFactory.Instance.CreatePet(type, owner, new Vector2(-1, -2), Quaternion.identity));
    }
}