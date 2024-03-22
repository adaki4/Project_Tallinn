using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region references
    public static GameManager instance;
    public PlayerManager playerManager;
    public UIManager uiManager;
    #endregion

    #region methods
    public void PausePlay()
    {
        Debug.Log("gAme");
        playerManager.PlayerPause();
        //more things to pause/deactivate
    }
    public void ResumePlay()
    {
        playerManager.PlayerResume();
    }
    #endregion
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
       /// playerManager.player = GameObject.Find("Player");

        if (SceneManager.GetActiveScene().name != "MainMenu"&&playerManager==null)
        {
            playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
