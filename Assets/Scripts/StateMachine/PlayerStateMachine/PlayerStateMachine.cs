using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlayerStateMachine : IStateMachine
{
    public IPlayer player { get;protected set; }
    public PlayerStateMachine(IPlayer player):base()
    {
        this.player = player;
    }
}