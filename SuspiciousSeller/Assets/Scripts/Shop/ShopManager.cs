using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public GameObject upgradeStore; //reference to gameobject shop
    public GameObject storeVisual; //visual of the shop (maybe w the addons it is not needed)

    //different aspects the shop can take (addons)
    protected List <int> boughtUpgrades;
    public  GameObject[] oldElements;
    public GameObject[] newElements;

    //number of upgrades as a condition to winning, an inizialised array would be needed if the condition was to complete all of them or specific ones
    private int currentUpgradesN;
    public int winUpgradesN=3; //how many upgrades do we need to win

    public static ShopManager instance;

    public event Action OnUpgradeShopOpen;
    public event Action OnUpgradeShopClose;
    public event Action OnMoneyChanged;

    private bool shopOpen;

    void Awake()
    {
        if (instance != null)
        {
            //Debug.LogWarning("More than one instance of Shop Manager found!");
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

    }
    public bool Sell(Item item)
    {
        if (!shopOpen) { return false; }

        GameManager.instance.AddMoneyToPlayer(item.value);
        OnMoneyChanged?.Invoke();
        //more things? idk make it more interesting
        return true;
    }
    public bool Buy(Upgrade upgrade)
    {   
        if(GameManager.instance.SpendMoneyPlayer(upgrade.value))
        {
            //activate image of upgrade and check if some are now locked
            //shopImages[upgrade.name].SetActive(true);

            oldElements[upgrade.imageObjId].SetActive(false);
            newElements[upgrade.imageObjId].SetActive(true);
            boughtUpgrades.Add(upgrade.imageObjId);

            OnMoneyChanged?.Invoke();

            //win condition
            currentUpgradesN++;
            if(AreUpgradesCompleted())
            {
                ShowUpgradeShop(false);
                OnUpgradeShopClose?.Invoke();
                GameManager.instance.EndGame();
            }
            return true;
        }
        return false;
    }

    public void ShowUpgradeShop(bool c)
    {
        if (c) OnUpgradeShopOpen?.Invoke(); 
        else
        { 
            OnUpgradeShopClose?.Invoke();
        }
        upgradeStore.SetActive(c);
        shopOpen = c;
    }

    public void OnChangeScene()
    {
        ShowStoreBuilding(ScenesManager.instance.GetCurrentSceneName() != "StoreScene"); //the event happens before names update
    }
    public void ShowStoreBuilding(bool c)
    {
        storeVisual.SetActive(c);
        for(int i = 0; i < boughtUpgrades.Count; i++)
        {
            ShowUpgradeVisual(i);
        }
        Debug.Log("Allo");
    }
    public bool AreUpgradesCompleted()
    {
        return currentUpgradesN >= winUpgradesN;
    }

    protected void ShowUpgradeVisual(int id)
    {
        oldElements[id].SetActive(false);
        newElements[id].SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        upgradeStore.SetActive(false);
        if (upgradeStore == null)
        upgradeStore = GameObject.Find("UpgradesShop");

        upgradeStore.SetActive(false);

        ScenesManager.instance.OnChangeScene += OnChangeScene;

        boughtUpgrades= new List<int> {};
        currentUpgradesN = 0;
        shopOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
