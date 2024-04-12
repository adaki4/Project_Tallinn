using UnityEngine;
using static UnityEditor.Progress;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Shop/Upgrade")]
public class Upgrade : ScriptableObject
{
    new public string name = "New Upgrade";    
    public Sprite icon = null;              
    public int value = 0; //buying value of the upgrade
    
    //upgrade points/level --> to change the level /complete the shop (tbd)

}
