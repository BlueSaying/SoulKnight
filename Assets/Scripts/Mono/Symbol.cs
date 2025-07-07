using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Symbol:MonoBehaviour
{
    public ICharacter character {  get; protected set; }

    public void SetCharacter(ICharacter character)
    {
        this.character = character;
    }
}