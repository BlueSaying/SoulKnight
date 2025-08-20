using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInfoPanel : Panel
{
    public void RefreshPanel()
    {
        GameObject weaponCanPickUp = SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer.weaponsCanPickUp.FirstOrDefault();
        if (weaponCanPickUp == default)
        {
            Debug.Log(1);
            return;
        }

        WeaponModel weaponModel = SystemRepository.Instance.GetSystem<WeaponSystem>().
            GetWeaponModel(System.Enum.Parse<WeaponType>(weaponCanPickUp.name));

        // refresh Damage
        UnityTools.Instance.GetTransformFromChildren(gameObject, "Damage").
            Find("Value").GetComponent<Text>().text = weaponModel.staticAttr.damage.ToString();

        // refresh EnergyCost
        UnityTools.Instance.GetTransformFromChildren(gameObject, "EnergyCost").
            Find("Value").GetComponent<Text>().text = weaponModel.staticAttr.energyCost.ToString();

        // refresh CriticalRate
        UnityTools.Instance.GetTransformFromChildren(gameObject, "CriticalRate").
            Find("Value").GetComponent<Text>().text = weaponModel.staticAttr.criticalRate.ToString();

        // refresh ScatterRate
        UnityTools.Instance.GetTransformFromChildren(gameObject, "ScatterRate").
            Find("Value").GetComponent<Text>().text = weaponModel.staticAttr.scatterRate.ToString();

        // refresh weapon type
    }
}