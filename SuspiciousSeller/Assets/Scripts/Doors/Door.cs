

using System;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] 
    private string _targetScene;
    
    [SerializeField]    
    private Vector3 _offset = Vector3.zero;
    void Start() {
        canInteract = true;
        if (GameManager.instance.canMovePlayer && ScenesManager.instance.lastScene == _targetScene) {
            canInteract = false;
            PlayerManager.instance.PlayerMovement.MoveInstantly(gameObject.transform.position + _offset);
        }
    }
    public override void Interact()
    {
        ScenesManager.instance.LoadScene(_targetScene);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (canInteract && collision.GetComponent<PlayerAttack>() != null) 
        {
            canInteract = false;
            Interact();
        }
    }
}