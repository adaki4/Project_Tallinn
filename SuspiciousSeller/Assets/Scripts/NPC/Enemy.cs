using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{
    #region references
    private Transform _target;
    #endregion
    private bool _moveToPlayer;
    #region variables
    [SerializeField]
    private float _movementSpeed = 9;
    [SerializeField]
    private float _rotationSpeed = 9;
    #endregion
    void Awake() {
        _target = PlayerManager.instance.player.transform;
        _moveToPlayer = true;
    }
    void OnTriggerEnter2D() {
        _moveToPlayer = false;
    }
    void OnTriggerExit2D() {
        _moveToPlayer = true;
    }
    
    void Update() {
        if (_moveToPlayer) {
            Vector3 dir = _target.position - transform.position;

            transform.up = Vector3.MoveTowards(transform.up, dir, _rotationSpeed);
            transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, _movementSpeed * Time.deltaTime);
        }
    }

}
