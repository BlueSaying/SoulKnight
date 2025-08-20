using Generic;
using UnityEngine;

public class PickUpableWeapon : MonoBehaviour
{
    // 使用isPlayerEnter来储存当前玩家是否可以拾取枪械
    // 使得Update方法只在玩家进入可拾取范围时调用
    private bool isPlayerEnter;

    private Player player;

    private void Update()
    {
        if (isPlayerEnter)
        {
            if (SystemRepository.Instance.GetSystem<InputSystem>().GetKeyDownInput(KeyInputType.PickUp))
            {
                player.AddWeapon(SystemRepository.Instance.GetSystem<WeaponSystem>().GetWeaponModel(System.Enum.Parse<WeaponType>(name)));
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 与玩家碰撞
        if (collision.CompareTag("Player"))
        {
            isPlayerEnter = true;
            player = collision.GetComponent<Symbol>().character as Player;
            player.weaponsCanPickUp.Insert(0, gameObject);

            if (!UIMediator.Instance.IsPanelOpened(PanelName.WeaponInfoPanel.ToString()))
            {
                UIMediator.Instance.OpenPanel(SceneName.Generic, PanelName.WeaponInfoPanel.ToString());
            }

            (UIMediator.Instance.GetPanel(PanelName.WeaponInfoPanel.ToString()) as WeaponInfoPanel).RefreshPanel();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 与玩家碰撞
        if (collision.CompareTag("Player"))
        {
            isPlayerEnter = false;
            player.weaponsCanPickUp.Remove(gameObject);

            if (player.weaponsCanPickUp.Count <= 0)
            {
                UIMediator.Instance.ClosePanel(PanelName.WeaponInfoPanel.ToString());
            }
            else
            {
                (UIMediator.Instance.GetPanel(PanelName.WeaponInfoPanel.ToString()) as WeaponInfoPanel).RefreshPanel();
            }
        }
    }
}