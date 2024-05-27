using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class ScenesManager : MonoBehaviour
{
    static public ScenesManager instance;

    public string lastScene;

    public event Action OnChangeScene;
    public void NewGame()
    {
        SceneManager.LoadScene("StoreScene");
    }
    public void LoadIntro()
    {
        SceneManager.LoadScene("Introduction");
    }
    public void LoadScene(string name)
    {
        OnChangeScene?.Invoke();
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
