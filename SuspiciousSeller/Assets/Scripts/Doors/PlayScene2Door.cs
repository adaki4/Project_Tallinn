using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScene2Door : MonoBehaviour
{   
    void Start() {
        if (GameManager.instance.canMovePlayer && ScenesManager.instance.lastScene == "PlayScene2") {
            PlayerManager.instance.PlayerMovement.MoveInstantly(gameObject.transform.position);
        }
    }
}
