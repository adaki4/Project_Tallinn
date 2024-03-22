using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region references
    [SerializeField]
    private GameObject _resumeButton;
    [SerializeField]
    private GameObject _pauseButton;
    public static UIManager instance;
    #endregion

    #region methods
   
    public void PauseScene()
    {
        Debug.Log("UI");
        GameManager.instance.PausePlay();
        _resumeButton.SetActive(true);
        _pauseButton.SetActive(false);
    }
    public void ResumeScene()
    {
        GameManager.instance.ResumePlay();  
        _resumeButton.SetActive(false);
        _pauseButton.SetActive(true);
    }
    public void NewGame()
    {
        ScenesManager.instance.NewGame();
    }
    #endregion
    private void Awake()
    {
        if (instance != null)
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
