using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameMediator : AbstractMediator
{
    private static GameMediator _instance;

    public static GameMediator Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameMediator();
            }
            return _instance;
        }
    }

    private GameMediator() { }
}