using UnityEngine;

public class ItemPickup : Interactable {

	public Item item;	// Item to put in the inventory on pickup

	// When the player interacts with the item
	public override void Interact()
	{
		base.Interact();

		PickUp();	// Pick it up!
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canInteract)
        {
            canInteract = false;
            Interact();
        }
        // PlayerManager.instance.PlayerMovement.MoveInstantly(collision.gameObject.transform.position);
    }

    // Pick up the item
    void PickUp ()
	{
		Debug.Log("Picking up " + item.name);
		bool wasPickedUp = Inventory.instance.Add(item);	// Add to inventory

		// If successfully picked up
		if (wasPickedUp)
			Destroy(gameObject);	// Destroy item from scene
	}

}
