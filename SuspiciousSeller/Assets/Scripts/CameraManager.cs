using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    public static CameraManager instance;
    

    private Camera cam;
    [SerializeField]
    public Vector2 minimalOffset;
    [SerializeField]
    public Vector2 maximalOffset;

    public Vector2 minimalScreenPosition;
    public Vector2 maximalScreenPosition;
    public float topScreenLimit;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        cam = Camera.main;
        minimalScreenPosition = new Vector2(cam.transform.position.x - cam.orthographicSize * Screen.width / Screen.height, - cam.orthographicSize);
        maximalScreenPosition = new Vector2(- minimalScreenPosition.x, cam.orthographicSize);
        topScreenLimit = maximalScreenPosition.y - (instance.maximalScreenPosition.y * 2 / 3) ;

    }
}
