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
        mainPlayer = PlayerFactory.Instance.GetPlayer(playerType);
        //mainPlayer.SetPlayerInput(GameMediator.Instance.GetController<InputController>().input);
    }

    public void AddPlayerPet(PetType type, Player owner)
    {
        pets.Add(PetFactory.Instance.GetPet(type, owner));
    }

    //public void SetMainPlayerSkin(PlayerSkinType skinType)
    //{
    //    if (mainPlayer == null) throw new System.Exception("无角色，无法设置皮肤");
    //
    //    //implement this function
    //    //mainPlayer
    //}
}