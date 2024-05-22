using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : NPC
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.GetComponent<PlayerInput>() != null)
       {
            //speak -> show text
            //show upgrade shop if they decide so(?)
            //move to center(?) 
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
