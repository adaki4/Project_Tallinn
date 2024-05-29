using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public abstract class Weapon : MonoBehaviour {
    
    [SerializeField]
    protected Transform attackTransform;
    [SerializeField]
    protected LayerMask attackableLayer;
    // [SerializeField]
    // protected int damage;
    [Range(0.1f, 1f)]
    [SerializeField]
    protected float fireRate;
    protected float lastAttackedAt = 0;
    [SerializeField]
    protected float attackRange;
    [SerializeField]
    public Sprite sprite; 
    [HideInInspector]
    public Animation attackAnimation;
    public abstract void Attack();

    protected void Start() {
        attackAnimation = GetComponentInChildren<Animation>();
    }
}