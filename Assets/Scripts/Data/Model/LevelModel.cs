
public class LevelModel : AbstractModel
{
    public LevelStaticAttr LevelStaticAttr { get; protected set; }

    public LevelModel(LevelStaticAttr LevelStaticAttr)
    {
        this.LevelStaticAttr = LevelStaticAttr;
    }
}