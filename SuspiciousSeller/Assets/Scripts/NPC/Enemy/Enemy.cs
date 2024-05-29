using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : NPC
{
    protected Transform target;
    protected Quaternion relativeAttackRotation;
    protected Vector3 scale;
    [SerializeField]
    protected int damageInCoins;
    [SerializeField]
    protected float movementSpeed = 2;
    [SerializeField]
    protected Transform firingPoint;

    protected void Awake() {
        scale = transform.localScale;
        target = PlayerManager.instance.player.transform;
    }

    protected void Update() {
        if (PlayerManager.instance.player.transform.position.x > transform.position.x ) {
            if (firingPoint != null) {
                relativeAttackRotation.z = firingPoint.transform.localRotation.z;
            }
            transform.localScale = new Vector2(scale.x, scale.y);
        }
        else {
            if (firingPoint != null) {
                relativeAttackRotation.z = - firingPoint.transform.localRotation.z;
            }
            transform.localScale = new Vector2(-scale.x, scale.y);
        }
    }

}
