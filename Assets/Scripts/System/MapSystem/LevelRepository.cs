using System.Collections.Generic;

public class LevelRepository
{
    Dictionary<LevelType, LevelModel> models;

    public LevelRepository()
    {
        models = new Dictionary<LevelType, LevelModel>();

        foreach (LevelType levelType in System.Enum.GetValues(typeof(LevelType)))
        {
            var levelStaticAttr = SOLoader.GetLevelSO(levelType).attrs;
            models.Add(levelType, new LevelModel(levelStaticAttr));
        }
    }

    public LevelModel GetLevelModel(LevelType levelType)
    {
        return models[levelType];
    }
}