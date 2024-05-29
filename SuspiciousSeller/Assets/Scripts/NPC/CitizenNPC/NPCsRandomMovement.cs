 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCsRandomMovement : MonoBehaviour {
    
    [SerializeField]
    private float _movementSpeed;
    private bool _YEdgeDirection;
    private Vector2 _randomTarget = new Vector2(0, 0);
    private System.Random _random = new System.Random();
    
    private void ChangeDirection() {
        int newX, newY;
        if (_YEdgeDirection) {
            newX = _random.Next((int) CameraManager.instance.minimalScreenPosition.x, (int) CameraManager.instance.maximalScreenPosition.x);
            newY = (int) minimalOrMaximalEdge( CameraManager.instance.minimalScreenPosition.y, CameraManager.instance.topScreenLimit);
            _YEdgeDirection = false;
        }
        else {
            newX = (int) minimalOrMaximalEdge( CameraManager.instance.minimalScreenPosition.x, CameraManager.instance.maximalScreenPosition.x);
            newY = _random.Next((int) CameraManager.instance.minimalScreenPosition.y, (int) CameraManager.instance.topScreenLimit);
            _YEdgeDirection = true;
        }

        _randomTarget.x = newX;
        _randomTarget.y = newY;
    }
    private float minimalOrMaximalEdge(float minimalEdge, float maximalEdge) {
        if (_random.Next(0, 2) == 0) {
            return minimalEdge;
        }
        return maximalEdge;
    }
    private bool IsOnScreenEdge() {
        if ( transform.position.x - 1 <  CameraManager.instance.minimalScreenPosition.x ||
             transform.position.x + 1  >  CameraManager.instance.maximalScreenPosition.x ||
             transform.position.y - 1 <  CameraManager.instance.minimalScreenPosition.y ||
             transform.position.y + 1 >  CameraManager.instance.topScreenLimit) {
                return true;
            }
        return false;
    }
    private void Start() {
        ChangeDirection();
    }
    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, _randomTarget, _movementSpeed * Time.deltaTime);
        if (IsOnScreenEdge()) {
            ChangeDirection();
        }
    }
}