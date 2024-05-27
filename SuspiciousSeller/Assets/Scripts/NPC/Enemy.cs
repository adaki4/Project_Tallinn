using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC 
{
    [SerializeField]
    private int damageInCoins;

    [SerializeField]
    private bool meleeActive;

    [SerializeField]
    private bool longRangeActive;

    private void OnTriggerEnter2D(Collider2D other) {
    if (meleeActive) {
        var player = other.gameObject.GetComponent<PlayerManager>();
        if (player != null) {
            player.SubstractMoney(damageInCoins);
            }
        }
    }
    

}
