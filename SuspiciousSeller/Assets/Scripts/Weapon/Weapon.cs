using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Weapon : MonoBehaviour {
    
    [SerializeField]
    protected Transform attackTransform;
    [SerializeField]
    protected LayerMask attackableLayer;
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected float fireRate;
    [SerializeField]
    protected float attackRange;

    public abstract void Attack();
}