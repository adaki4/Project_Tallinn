using UnityEngine;
using UnityEngine.UI;
/* The base item class. All items should derive from this. */

public enum UpgradeState {Locked, Unlocked, Used};

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Shop/Upgrade")]
public class Upgrade : ScriptableObject
{
    new public string name = "New Upgrade";
    public string description = "Description";
    public int imageObjId;
    public UpgradeState state= UpgradeState.Locked;
    public Image icon = null; 
    public int value = 0; //buying value of the upgrade
    
    //upgrade points/level --> to change the level /complete the shop (tbd)

}
