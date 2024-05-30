using UnityEngine;

/*	
	This component is for all objects that the player can
	interact with such as enemies, items etc. It is meant
	to be used as a base class.
*/

public class Interactable : MonoBehaviour {

    [SerializeField]
    protected bool canInteract;
	public virtual void Interact ()
	{
		// This method is meant to be overwritten
		//Debug.Log("Interacting with " + transform.name);
	}
    void Start() {
    }
    private void OnTriggerExit2D(Collider2D other) {
        canInteract = true;
    }

}
