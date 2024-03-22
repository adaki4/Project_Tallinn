using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantDoor : MonoBehaviour
{ 
    void Start() {
        if (GameManager.instance.canMovePlayer) {
            PlayerManager.instance.PlayerMovement.MoveInstantly(gameObject.transform.position);
        }
    }
}
