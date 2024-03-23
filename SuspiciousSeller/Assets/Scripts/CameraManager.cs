using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region references
    public static CameraManager instance;
    #endregion

    #region variables
    private Camera cam;
    [SerializeField]
    public Vector2 minimalScreenPosition;
    [SerializeField]
    public Vector2 maximalScreenPosition;
    public float topScreenLimit;
    #endregion
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
