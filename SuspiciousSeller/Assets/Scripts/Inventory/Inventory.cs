using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public static Inventory instance;

	void Awake ()
	{
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
            Debug.LogWarning("More than one instance of Inventory found!");
        }
	}


	// Callback which is triggered when
	// an item gets added/removed.
	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int space = 20;	// Amount of slots in inventory

	// Current list of items in inventory
	public List<Item> items = new List<Item>();

	// Add a new item. If there is enough room we
	// return true. Else we return false.
	public bool Add (Item item)
	{
        // Check if out of space
        if (items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }

        items.Add(item);	// Add item to list

        // Trigger callback
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
		return true;
	}

	// Remove an item
	public void Remove (Item item)
	{
		items.Remove(item);		// Remove item from list

		// Trigger callback
		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

}
