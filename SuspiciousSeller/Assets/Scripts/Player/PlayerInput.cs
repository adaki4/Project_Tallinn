using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Start is called before the first frame update
    #region references
    PlayerMovement _movementComponent;
    Camera _mainCamera;
    #endregion
    #region methods
    #endregion
    void Start()
    {
        _movementComponent= GetComponent<PlayerMovement>();
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //general input comprobation? getanykeydown true then see which one you clicked on-> have a list of keys to check?
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //checking if the mouse is hovering over a ui
            //turning the clicked point to a world point
            //
            //get click position on screen
            Vector3 screenClickPosition = Input.mousePosition;

            //convert to in game point
            Vector2 worldClickPositon= _mainCamera.ScreenToWorldPoint(screenClickPosition);

            //check if you can move that point (set limits)
            //do we hit something? colliding, not raycasting?
            _movementComponent.GoToPoint(worldClickPositon);

            //movement
            //buying things
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            //shoot
        }
    }
}
