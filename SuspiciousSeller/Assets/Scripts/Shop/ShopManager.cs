using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopManager : MonoBehaviour
{
    public GameObject UpgradeStore;

    //different aspects the shop can take (different images as a whole vs addons?)
    Dictionary<string, GameObject> shopImages = new Dictionary<string, GameObject>();
    private int _level; 

    public static ShopManager instance;

    public event Action OnUpgradeShopOpen;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Shop Manager found!");
            return;
        }

        instance = this;
    }
    public bool Buy(Upgrade upgrade)
    {   
        if(GameManager.instance.SpendMoneyPlayer(upgrade.value))
        {
            //shopImages[upgrade.name].SetActive(true);
            return true;
        }
        return false;
    }

    public void ShowUpgradeShop(bool c)
    {
        Debug.Log("abreindo tienda");
        OnUpgradeShopOpen?.Invoke();
        UpgradeStore.SetActive(c);
    }
    // Start is called before the first frame update
    void Start()
    {
        UpgradeStore.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
