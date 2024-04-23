using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCsDirectedMovement : MonoBehaviour {

    references
    private Transform _target;
    
    private bool _moveToPlayer;
    variables
    [SerializeField]
    private float _movementSpeed = 2;
    [SerializeField]
    private float _rotationSpeed = 0.2f;
    
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
