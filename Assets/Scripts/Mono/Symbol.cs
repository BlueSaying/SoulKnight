using UnityEngine;

public class Symbol : MonoBehaviour
{
    public ICharacter character { get; protected set; }

    public void SetCharacter(ICharacter character)
    {
        this.character = character;
    }
}