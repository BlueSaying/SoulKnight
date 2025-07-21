using UnityEngine;

public class Stake : Enemy
{
    public Stake(GameObject obj, EnemyModel model) : base(obj, model)
    {

    }

    protected override void OnCharacterUpdate()
    {
        base.OnCharacterUpdate();

        //Debug.Log(this.ToString());
    }

    //public override string ToString()
    //{
    //    return base.ToString() + "属性详情  "
    //        + "名称：" + staticAttr.name
    //        + "生命最大值" + staticAttr.maxHp.ToString()
    //        + "是否为精英怪" + staticAttr.isElite.ToString()
    //        + "敌人类型" + staticAttr.enemyType.ToString()
    //        + "武器类型" + staticAttr.enemyWeaponType.ToString();
    //}
}