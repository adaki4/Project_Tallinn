using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    public static CameraManager instance;
    

    private Camera _cam;
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
        _cam = Camera.main;
        minimalScreenPosition = new Vector2(_cam.transform.position.x - _cam.orthographicSize * Screen.width / Screen.height, - _cam.orthographicSize);
        maximalScreenPosition = new Vector2(- minimalScreenPosition.x, _cam.orthographicSize);
        topScreenLimit = maximalScreenPosition.y - (instance.maximalScreenPosition.y * 2 / 3) ;

    }
}
