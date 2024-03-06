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
    private Vector3 _target;
    #endregion
    #region methods
    public bool GoToPoint(Vector2 point)
    {
        if((point.y<_topLimit))//&&is inside of screen limits
        {
            _target= point;
        }
        return false;
    }
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position);
        transform.position=Vector3.MoveTowards(transform.position, _target, _speed*Time.deltaTime);
    }
}
