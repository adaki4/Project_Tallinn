using System;
using UnityEngine;
using UnityEngine.UIElements;
public class LongRangeWeapon : Weapon
{
    [SerializeField] 
    private GameObject bulletPrefab;
    private Vector3 relativeAttackTransformPosition;
    private Quaternion relativeAttackRotation;

 
    public override void Attack()
    {
        Instantiate(bulletPrefab, relativeAttackTransformPosition, relativeAttackRotation);
    }
    void Start() {
        attackRange = 20f;
        fireRate = 0.5f;
    }
    void Update() {
        relativeAttackTransformPosition = attackTransform.position;
        relativeAttackRotation = attackTransform.rotation;
        if (!PlayerManager.instance.PlayerMovement.isGoingRight) {
            relativeAttackTransformPosition.x -= attackTransform.localPosition.x;
            relativeAttackRotation.z = -relativeAttackRotation.z;
            }
    }
}