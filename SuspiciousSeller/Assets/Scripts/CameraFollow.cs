using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField]
    private Vector3 offset;
    [Range(0f, 1f)]
    [SerializeField]
    private float smoothSpeed;

    private void LateUpdate() {
        if (PlayerManager.instance != null) {
            playerTransform = PlayerManager.instance.player.transform;
            Vector3 desiredPosition = playerTransform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime); 
            transform.position = smoothedPosition;
        }
    }
}
