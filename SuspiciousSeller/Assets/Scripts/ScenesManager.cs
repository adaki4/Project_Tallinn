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

    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
    public void LoadScene(string name)
    {
        OnChangeScene?.Invoke();
        lastScene = SceneManager.GetActiveScene().name;
        currentScene = name;
        SceneManager.LoadScene(name);
    }
    
    private void Awake()
    {
         if (instance != null)
         {
            Destroy(this);
            return;
         }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
