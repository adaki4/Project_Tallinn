using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    private bool moveToPlayer;
    private void OnTriggerEnter2D(Collider2D other) {
        PlayerManager playerManager = other.gameObject.GetComponent<PlayerManager>();
        if (playerManager != null) {
            moveToPlayer = false;
            Debug.Log("i touched player meele");
            GameManager.instance.SpendMoneyPlayer(damageInCoins, true);
        }
    }
    void OnTriggerExit2D() {
        moveToPlayer = true;
    }
    new void Awake() {
        base.Awake();
        moveToPlayer = true;
    }
    new void Update() {
        base.Update();
        if (moveToPlayer) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
        }
    }

}
