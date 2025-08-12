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
                PlayerWeaponModel model = SystemRepository.Instance.GetSystem<WeaponSystem>().
                    GetPlayerWeaponModel(System.Enum.Parse<PlayerWeaponType>(name));
                player.AddWeapon(model);
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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 与玩家碰撞
        if (collision.CompareTag("Player"))
        {
            isPlayerEnter = false;
        }
    }
}