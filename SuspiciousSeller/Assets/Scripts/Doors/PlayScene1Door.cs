using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScene1Door : Door
{ 
    void Start() {
        if (GameManager.instance.canMovePlayer && ScenesManager.instance.lastScene == "PlayScene1") {
            PlayerManager.instance.PlayerMovement.MoveInstantly(gameObject.transform.position);
        }
    }
    
}
