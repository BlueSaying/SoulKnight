using System;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // 使用isPlayerEnter来储存当前玩家是否可以拾取枪械
    // 使得Update方法只在玩家进入可拾取范围时调用
    private bool isPlayerEnter;

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

                // HACK:暂时随机实例化武器
                var array = Enum.GetValues(typeof(WeaponType));
                WeaponFactory.InstantiateWeapon((WeaponType)UnityEngine.Random.Range(0, (int)WeaponType._DivideLine_),
                    transform.Find("GenerationPoint").position, Quaternion.identity);

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

            itemArrow = ItemFactory.Instance.CreateItemArrow("ItemArrow", name, QualityType.White, transform.Find("ItemArrowPoint"));
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