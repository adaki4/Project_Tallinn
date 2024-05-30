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
    public Sprite sprite; 
    [SerializeField]
    protected AudioClip audioClip;
    [HideInInspector]
    public Animation attackAnimation;
    protected AudioSource audioSource;
    public abstract void Attack();
    protected void PlaySoundEffectAndAnimation(string animation) {
        audioSource.clip = audioClip;
        audioSource.Play();
        attackAnimation.Play(animation);
    }
    protected void Start() {
        attackAnimation = GetComponentInChildren<Animation>();
        audioSource = GetComponent<AudioSource>();
    }
}