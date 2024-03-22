using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    static public ScenesManager instance;
    // Start is called before the first frame update
    #region methods
    public void NewGame()
    {
        SceneManager.LoadScene("StoreScene");
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    #endregion
    //static public ScenesManager Instance
    //{
    //    get
    //    {
    //        return _instance;
    //    }
    //}
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
