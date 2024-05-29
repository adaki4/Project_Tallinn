using System;
using UnityEngine;
public class LongRangeWeapon : Weapon
{

    [SerializeField] 
    private GameObject bulletPrefab; 
    private Quaternion relativeAttackRotation;
 
    public override void Attack()
    {
        if (Time.time > lastAttackedAt + fireRate) {
            Instantiate(bulletPrefab, attackTransform.position, relativeAttackRotation);
        lastAttackedAt = Time.time;
        }
    }
    void Start() {
        attackRange = 20f;
        fireRate = 0.5f;
    }
    void Update() {
        relativeAttackRotation = attackTransform.localRotation;
        if (!PlayerManager.instance.PlayerMovement.isGoingRight) {
            relativeAttackRotation.z = -relativeAttackRotation.z;
        }
    }
}