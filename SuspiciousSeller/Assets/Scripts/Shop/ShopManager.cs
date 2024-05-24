using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public GameObject upgradeStore;

    //different aspects the shop can take (different images as a whole vs addons?)
    Dictionary<string, GameObject> shopImages = new Dictionary<string, GameObject>();
    private int _level; 

    public static ShopManager instance;
    public GameObject storeVisual;

    public event Action OnUpgradeShopOpen;
    public event Action OnMoneyChanged;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Shop Manager found!");
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

    }
    public bool Buy(Upgrade upgrade)
    {   
        if(GameManager.instance.SpendMoneyPlayer(upgrade.value))
        {
            //shopImages[upgrade.name].SetActive(true);
            OnMoneyChanged?.Invoke();
            return true;
        }
        return false;
    }

    public void ShowUpgradeShop(bool c)
    {
        Debug.Log("abreindo tienda");
        OnUpgradeShopOpen?.Invoke();
        upgradeStore.SetActive(c);
    }

    public void OnChangeScene()
    {
        ShowStoreBuilding(SceneManager.GetActiveScene().name == "StoreScene");
    }
    public void ShowStoreBuilding(bool c)
    {
        storeVisual.SetActive(c);
    }

    // Start is called before the first frame update
    void Start()
    {
        upgradeStore.SetActive(false);
        if (upgradeStore == null)
        upgradeStore = GameObject.Find("UpgradesShop");

        upgradeStore.SetActive(false);

        ScenesManager.instance.OnChangeScene += OnChangeScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
