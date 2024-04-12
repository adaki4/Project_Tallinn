using UnityEngine;
using static UnityEditor.Progress;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

	new public string name = "New Item";	// Name of the item
	public Sprite icon = null;              // Item icon
	public int value = 0; //selling value of the cloth

	// Called when the item is pressed in the inventory
	public virtual void Use ()
	{
		//sell the cloth (temporal-> player needs to be in the merchant mode)
        GameManager.instance.AddMoneyToPlayer(value);

        Debug.Log("Using " + name);
	}

	public void RemoveFromInventory ()
	{
		Inventory.instance.Remove(this);
	}
	
}
