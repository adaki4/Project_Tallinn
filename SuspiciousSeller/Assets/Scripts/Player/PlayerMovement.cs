using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 50;
    [SerializeField]
    private Vector3 _target;
    private Camera _cam;
    private float minEnemyDistance = 0.1f;
    bool _isMoving;

    

    // Move to the point if clicked inside playable area
    public void GoToPoint(Vector2 point)
    {
        //version 1 -> hard limit
        // if (point.y < _topLimit
        //     && _minimalScreenPosition.x < point.x
        //     && _minimalScreenPosition.y < point.y
        //     && point.x < _maximalScreenPosition.x
        //     && point.y < _maximalScreenPosition.y
        //     )
        // {
        //     _target= point;
        // }
        // version 2 -> clamp
        _isMoving = true;
        _target.x = Mathf.Clamp(point.x, CameraManager.instance.minimalScreenPosition.x, CameraManager.instance.maximalScreenPosition.x);
        _target.y = Mathf.Clamp(point.y, CameraManager.instance.minimalScreenPosition.y, CameraManager.instance.topScreenLimit);
        
    }

    public void UpdateCamera()
    {
        if (_cam != null) { _cam = Camera.main; } 
    }
    public void MoveInstantly(Vector2 point) {
        _isMoving = false;
        transform.position = point;
    }
    

    void Start()
    {
        _cam = Camera.main;
        _isMoving = false;
    }

    void Update()
    {
        if (_isMoving) { 
            Debug.Log(transform.position);
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed*Time.deltaTime);
            
            if (Vector3.Distance(transform.position, _target) <= minEnemyDistance) { _isMoving = false; } //remember checking cases where player cant arrive at point (colision, not exact point etc)
        }
    }
}
