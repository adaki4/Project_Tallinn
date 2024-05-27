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

    public string currentScene;

    public event Action OnChangeScene;
    public void NewGame()
    {
        SceneManager.LoadScene("StoreScene");
    }
    public void LoadIntro()
    {
        SceneManager.LoadScene("Introduction");
    }

    public string GetCurrentSceneName() //unity get active scene.name was not working for some reason
    {
        return currentScene;
    }
    public void LoadScene(string name)
    {
        OnChangeScene?.Invoke();
        lastScene = SceneManager.GetActiveScene().name;
        currentScene = name;
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
