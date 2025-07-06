using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class AbstractModel
{
    public AbstractModel()
    {
        OnInit();
    }
    protected virtual void OnInit()
    {

    }

}