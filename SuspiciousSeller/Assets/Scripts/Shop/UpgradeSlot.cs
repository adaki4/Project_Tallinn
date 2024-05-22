using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSlot : MonoBehaviour
{
    /// </summary>
    public Upgrade upgrade;
    public TMP_Text priceText;
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public Image overlay;
    public Image icon;


    //bool  active?
    void Start()
    {
        ShopManager.instance.OnUpgradeShopOpen += CheckLocked;

        nameText.SetText( upgrade.name);
        descriptionText.SetText(upgrade.description);
        priceText.SetText((upgrade.value).ToString());
        icon =upgrade.icon;
    }

    public void OnClickUpgrade()
    {
        if (upgrade.state == UpgradeState.Unlocked && ShopManager.instance.Buy(upgrade))
        {
            upgrade.state = UpgradeState.Used;
            Destroy(gameObject);
        }
        // Start is called before the first frame update
    }

    public void CheckLocked()
    {
        //change to paremters in event? like this is not the best
        if(upgrade.state == UpgradeState.Locked && GameManager.instance.canAffordPlayer(upgrade.value))
        {
            overlay.enabled = false;
            upgrade.state = UpgradeState.Unlocked;
        }
    }

    private void OnDestroy()
    {
        ShopManager.instance.OnUpgradeShopOpen -= CheckLocked;
    }
}

