using UnityEngine;

public class Symbol : MonoBehaviour
{
    public Character character { get; protected set; }

    public void SetCharacter(Character character)
    {
        this.character = character;
    }
}