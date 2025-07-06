using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ModelContainer
{
    private ModelContainer _instance;
    public ModelContainer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ModelContainer();
            }
            return _instance;
        }
    }
    private Dictionary<Type, AbstractModel> modelDic;
    private ModelContainer()
    {
        modelDic = new Dictionary<Type, AbstractModel>();
    }
    public T GetModel<T>() where T : AbstractModel
    {
        if(!modelDic.ContainsKey(typeof(T)))
        {
            return modelDic[typeof(T)] as T;
        }

        return default;
    }
}