using UnityEngine;

public class Chest : MonoBehaviour
{
    // 使用isPlayerEnter来储存当前玩家是否可以拾取枪械
    // 使得Update方法只在玩家进入可拾取范围时调用
    private bool isPlayerEnter;

    private Player player;

    private ItemArrow itemArrow;

    private bool isOpen;

    private void Update()
    {
        if (isOpen) return;

        if (isPlayerEnter)
        {
            if (SystemRepository.Instance.GetSystem<InputSystem>().GetKeyDownInput(KeyInputType.PickUp))
            {
                // 开启宝箱
                isOpen = true;

                gameObject.GetComponent<Animator>().SetTrigger("OpenChest");

                // HACK
                WeaponFactory.InstantiateWeapon(WeaponType.GatlingGun, transform.Find("GenerationPoint").position, Quaternion.identity);

                Destroy(itemArrow.transform.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOpen) return;

        // 与玩家碰撞
        if (collision.CompareTag("Player"))
        {
            isPlayerEnter = true;
            player = collision.GetComponent<Symbol>().character as Player;

            itemArrow = ItemFactory.Instance.CreateItemArrow("ItemArrow", name, transform.Find("ItemArrowPoint"));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isOpen) return;

        // 与玩家碰撞
        if (collision.CompareTag("Player"))
        {
            isPlayerEnter = false;

            Destroy(itemArrow.transform.gameObject);
        }
    }
}