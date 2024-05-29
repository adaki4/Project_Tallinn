using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    private bool moveToPlayer;
    private void OnTriggerEnter2D(Collider2D other) {
        var player = other.GetComponent<PlayerManager>();
            if (player != null) {
                moveToPlayer = false;
                player.SubstractMoney(damageInCoins);
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
