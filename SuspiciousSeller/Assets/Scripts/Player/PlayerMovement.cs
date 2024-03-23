using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float _speed = 50;
    [SerializeField]
    private Vector3 _target;
    private Camera cam;
    bool _isMoving;

    #endregion

    #region methods
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
        if (cam != null) { cam = Camera.main; } 
    }
    public void MoveInstantly(Vector2 point) {
        _isMoving = false;
        transform.position = point;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        _isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isMoving) { 
            Debug.Log(transform.position);
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed*Time.deltaTime);
            
            if (transform.position == _target) { _isMoving = false; } //remember checking cases where player cant arrive at point (colision, not exact point etc)
        }
    }
}
