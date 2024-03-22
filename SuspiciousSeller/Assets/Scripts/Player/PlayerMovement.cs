using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float _topLimit=5000;
    [SerializeField]
    private float _speed=50;
    [SerializeField]
    private Vector3 _target;
    private Camera cam;
    private Vector2 _minimalScreenPosition;
    private Vector2 _maximalScreenPosition;
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
        _isMoving= true;
        _target.x = Mathf.Clamp(point.x, _minimalScreenPosition.x, _maximalScreenPosition.x);
        _target.y = Mathf.Clamp(point.y, _minimalScreenPosition.y, _topLimit);
    }

    public void UpdateCamera()
    {
        if (cam != null) { cam = Camera.main; } 
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        _minimalScreenPosition = new Vector2(cam.transform.position.x - cam.orthographicSize * Screen.width / Screen.height, - cam.orthographicSize);
        _maximalScreenPosition = new Vector2(- _minimalScreenPosition.x, cam.orthographicSize);
        _topLimit = _maximalScreenPosition.y - (_maximalScreenPosition.y * 2 / 3) ;
        _isMoving= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isMoving) { 
            Debug.Log(transform.position);
            transform.position=Vector3.MoveTowards(transform.position, _target, _speed*Time.deltaTime);
            
            if(transform.position==_target) { _isMoving = false; } //remember checking cases where player cant arrive at point (colision, not exact point etc)
        }
    }
}
