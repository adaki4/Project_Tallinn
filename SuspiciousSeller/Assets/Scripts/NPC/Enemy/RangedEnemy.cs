using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class RangedEnemy : Enemy
{
    private float lastAttackedAt;
    [SerializeField]
    private float attackRate;
    [SerializeField]
    private float distanceToShoot;
    [SerializeField]
    private float distanceToStop;
    [SerializeField] 
    private GameObject bulletPrefab;

    private void Shoot() {
        if (Time.time > lastAttackedAt + attackRate) {
            Debug.Log("enemy shooting");
            lastAttackedAt = Time.time;
            
            GameObject bullet = Instantiate(bulletPrefab, firingPoint.transform.position, relativeAttackRotation);
            BulletComponent bulletComponent = GetComponent<BulletComponent>();
            if (bulletComponent != null) {
                bulletComponent.damageToPlayerInCoins = damageInCoins;
            }
        }
    }
    new void Awake() {
        base.Awake();
        scale = transform.localScale;
        relativeAttackRotation = firingPoint.transform.rotation;
    }
    new void Update() {
        base.Update();
        if (Vector2.Distance(target.position, transform.position) >= distanceToStop) {

            transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);

        }
        else if (Vector2.Distance(target.position, transform.position) <= distanceToShoot) {
            Shoot();
        }
    }

}
