
using UnityEngine;

public class EnemyModel : CharacterModel
{
    public new EnemyStaticAttr staticAttr { get => base.staticAttr as EnemyStaticAttr; set => base.staticAttr = value; }
    public new EnemyDynamicAttr dynamicAttr { get => base.dynamicAttr as EnemyDynamicAttr; set => base.dynamicAttr = value; }

    public EnemyModel(EnemyStaticAttr staticAttr, EnemyDynamicAttr dynamicAttr) : base(staticAttr, dynamicAttr) { }

    public EnemyModel DeepCopy()
    {
        EnemyStaticAttr staticAttr = this.staticAttr.DeepCopy();
        EnemyDynamicAttr dynamicAttr = this.dynamicAttr.DeepCopy();

        return new EnemyModel(staticAttr, dynamicAttr);
    }
}
