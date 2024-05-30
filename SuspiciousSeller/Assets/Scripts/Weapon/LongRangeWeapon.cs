using System;
using UnityEngine;
public class LongRangeWeapon : Weapon
{

    [SerializeField]
    private GameObject bulletPrefab;

    private Quaternion relativeAttackRotation;

    public override void Attack() {
        if (Time.time > lastAttackedAt + fireRate) {
            PlaySoundEffectAndAnimation("Gun");
            Instantiate(bulletPrefab, attackTransform.position, relativeAttackRotation);
            lastAttackedAt = Time.time;
        }
    }
    void Update() {
        relativeAttackRotation = attackTransform.localRotation;
        if (!PlayerManager.instance.PlayerMovement.isGoingRight) {
            relativeAttackRotation.z = -relativeAttackRotation.z;
        }
    }
}