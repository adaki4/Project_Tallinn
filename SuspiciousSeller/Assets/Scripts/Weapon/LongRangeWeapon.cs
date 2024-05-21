using System;
using UnityEngine;
using UnityEngine.UIElements;
public class LongRangeWeapon : Weapon
{
    [SerializeField] 
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform firingPoint;
    private Vector3 relativeAttackTransformPosition;
    private Quaternion relativeAttackRotation;

 
    public override void Attack()
    {
        Instantiate(bulletPrefab, relativeAttackTransformPosition, relativeAttackRotation);
    }
    void Start() {
        damage = 20;
        attackRange = 20f;
        fireRate = 0.5f;
    }
    void Update() {
        relativeAttackTransformPosition = firingPoint.position;
        relativeAttackRotation = firingPoint.rotation;
        if (!PlayerManager.instance.PlayerMovement.isGoingRight) {
            relativeAttackTransformPosition.x -= firingPoint.localPosition.x;
            relativeAttackRotation.z = -relativeAttackRotation.z;
            }
    }
}