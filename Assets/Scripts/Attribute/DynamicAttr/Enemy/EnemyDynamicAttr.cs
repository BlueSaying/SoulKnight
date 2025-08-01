public class EnemyDynamicAttr : CharacterDynamicAttr
{

    public EnemyDynamicAttr DeepCopy()
    {
        EnemyDynamicAttr output = new EnemyDynamicAttr();
        output.curHP = curHP;
        return output;
    }
}
