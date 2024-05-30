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
    private float _minEnemyDistance = 0.1f;
    bool _isMoving;
    
    public bool isGoingRight;

    private Vector3 scale;
    

    // Move to the point if clicked inside playable area
    public void GoToPoint(Vector2 point)
    {
        _isMoving = true;
        _target.x = Mathf.Clamp(point.x, CameraManager.instance.minimalScreenPosition.x + CameraManager.instance.minimalOffset.x, CameraManager.instance.maximalScreenPosition.x + CameraManager.instance.maximalOffset.x);
        _target.y = Mathf.Clamp(point.y, CameraManager.instance.minimalScreenPosition.y, CameraManager.instance.topScreenLimit);
        isGoingRight = _target.x > transform.position.x;
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
        scale = transform.localScale;
        _cam = Camera.main;
        _isMoving = false;
    }

    void Update()
    {
        if (_isMoving) { 
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed*Time.deltaTime);
            
            if (Vector3.Distance(transform.position, _target) <= _minEnemyDistance) { _isMoving = false; }
            if (isGoingRight) {
                transform.localScale = new Vector3(scale.x, scale.y);
            }
            else {
                transform.localScale = new Vector3(-scale.x, scale.y);
            } //remember checking cases where player cant arrive at point (colision, not exact point etc)
        }
    }
}
