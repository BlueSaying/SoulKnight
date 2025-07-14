using UnityEngine;

public class PickUpableWeapon : MonoBehaviour
{
    // 使用isPlayerEnter来储存当前玩家是否可以拾取枪械
    // 使得Update方法只在玩家进入可拾取范围时调用
    private bool isPlayerEnter;

    private IPlayer player;

    private void Start() { }

    private void Update()
    {
        if (isPlayerEnter)
        {
            //if (Input.GetKeyDown(KeyCode.F))
            if (GameMediator.Instance.GetController<InputController>().GetKeyInput(KeyInputType.pickUp))
            {
                // TODO:捡起武器后按F仍有效果bug
                player.AddWeapon(System.Enum.Parse<PlayerWeaponType>(name));
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
            player = collision.GetComponent<Symbol>().character as IPlayer;
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