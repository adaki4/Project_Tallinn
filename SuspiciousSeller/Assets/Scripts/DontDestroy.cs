using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    #region references
    static DontDestroy instance;
    #endregion
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    //Start is called before the first frame update
    void Start()
    {

    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
