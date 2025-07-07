using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CollectWeapon:MonoBehaviour
{
    private bool isPlayerEnter;

    private IPlayer player;

    private void Start() { }

    private void Update()
    {
        if(isPlayerEnter)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                player.AddWeapon(System.Enum.Parse<PlayerWeaponType>(name));
                Destroy(gameObject);
                Debug.Log("捡起武器");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Enter");
            isPlayerEnter = true;
            player= collision.GetComponent<Symbol>().character as IPlayer;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isPlayerEnter = false;
        }
    }
}