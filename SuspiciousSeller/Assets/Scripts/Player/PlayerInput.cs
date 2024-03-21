using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    #region references
    PlayerMovement _movementComponent;
    PlayerAttack _attack;
    Camera _mainCamera;
    #endregion

    #region methods
    #endregion
    void Start()
    {
        _movementComponent = GetComponent<PlayerMovement>();
        _attack = GetComponent<PlayerAttack>();
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //general input comprobation? getanykeydown true then see which one you clicked on-> have a list of keys to check?
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //checking if the mouse is hovering over a ui element-> maybe it's not the most elegant way to do it, but it checks if the pointer is over
            //any of the objects of the event system (event system handles input, raycasting and events)
            if(!EventSystem.current.IsPointerOverGameObject())
            {
                //turning the clicked point to a world point
                //get click position on screen
                Vector3 screenClickPosition = Input.mousePosition;

                //convert to in game point
                Vector2 worldClickPositon = _mainCamera.ScreenToWorldPoint(screenClickPosition);

                //check if you can move that point (set limits)
                //do we hit something? colliding, not raycasting?
                _movementComponent.GoToPoint(worldClickPositon);

                //movement

            }

            //buying things
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //shoot
            _attack.Shoot();
        }
    }
}
