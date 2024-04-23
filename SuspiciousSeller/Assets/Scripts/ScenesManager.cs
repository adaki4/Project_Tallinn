using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    static public ScenesManager instance;

    public string lastScene; 
    methods
    public void NewGame()
    {
        SceneManager.LoadScene("StoreScene");
    }
    public void LoadScene(string name)
    {
        lastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);
    }
    
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
