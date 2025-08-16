public class CharacterModel : AbstractModel
{
    public CharacterStaticAttr staticAttr { get; protected set; }
    public CharacterDynamicAttr dynamicAttr { get; protected set; }

    public CharacterModel(CharacterStaticAttr staticAttr, CharacterDynamicAttr dynamicAttr)
    {
        this.staticAttr = staticAttr;
        this.dynamicAttr = dynamicAttr;

        // HACK
        Recover();
    }

    public virtual void Recover()
    {
        dynamicAttr.curHP = staticAttr.maxHP;
    }
}