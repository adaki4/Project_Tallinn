using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.GetComponent<PlayerInput>() != null)
       {
            ShopManager.instance.ShowUpgradeShop(true);
       }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerInput>() != null)
        {
            ShopManager.instance.ShowUpgradeShop(false);
        }
    }

}
