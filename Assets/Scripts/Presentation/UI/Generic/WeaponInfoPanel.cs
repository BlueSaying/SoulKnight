using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInfoPanel : Panel
{
    public Sprite pistolIcon;
    public Sprite rifleIcon;
    public Sprite shotGunIcon;
    public Sprite bowIcon;
    public Sprite meleeIcon;
    public Sprite strangeIcon;
    public Sprite staffIcon;

    protected override void DOClosePanel()
    {
        base.DOClosePanel();
        DestroyPanel();
    }

    public void RefreshPanel()
    {
        GameObject weaponCanPickUp = SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer.pickUpableList.FirstOrDefault();
        if (weaponCanPickUp == default)
        {
            return;
        }

        WeaponModel weaponModel = SystemRepository.Instance.GetSystem<WeaponSystem>().
            GetWeaponModel(System.Enum.Parse<WeaponType>(weaponCanPickUp.name));

        // refresh Damage
        UnityTools.GetTransformFromChildren(gameObject, "Damage").
            Find("Value").GetComponent<Text>().text = weaponModel.staticAttr.damage.ToString();

        // refresh EnergyCost
        UnityTools.GetTransformFromChildren(gameObject, "EnergyCost").
            Find("Value").GetComponent<Text>().text = weaponModel.staticAttr.energyCost.ToString();

        // refresh CriticalRate
        UnityTools.GetTransformFromChildren(gameObject, "CriticalRate").
            Find("Value").GetComponent<Text>().text = weaponModel.staticAttr.criticalRate.ToString();

        // refresh ScatterRate
        UnityTools.GetTransformFromChildren(gameObject, "ScatterRate").
            Find("Value").GetComponent<Text>().text = weaponModel.staticAttr.scatterRate.ToString();

        // refresh weapon type
        Image image = UnityTools.GetTransformFromChildren(gameObject, "WeaponIcon").Find("Icon").GetComponent<Image>();
        switch (weaponModel.staticAttr.weaponCategory)
        {
            case WeaponCategory.Bow:
                image.sprite = bowIcon;
                break;

            case WeaponCategory.Melee:
                image.sprite = meleeIcon;
                break;

            case WeaponCategory.Rifle:
                image.sprite = rifleIcon;
                break;

            case WeaponCategory.ShotGun:
                image.sprite = shotGunIcon;
                break;

            case WeaponCategory.Pistol:
                image.sprite = pistolIcon;
                break;

            case WeaponCategory.Strange:
                image.sprite = strangeIcon;
                break;

            case WeaponCategory.Staff:
                image.sprite = staffIcon;
                break;
        }
        image.SetNativeSize();
    }
}