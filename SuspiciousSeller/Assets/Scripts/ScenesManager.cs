using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    static public ScenesManager instance;

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

}
