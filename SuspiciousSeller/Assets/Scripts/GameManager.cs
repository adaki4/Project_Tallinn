using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    references
    public static GameManager instance;
    public PlayerManager playerManager;
    public UIManager uiManager;
    public bool canMovePlayer = false;
    

    methods
    public void PausePlay()
    {
        Debug.Log("Game");
        playerManager.PlayerPause();
        //more things to pause/deactivate
    }
    public void ResumePlay()
    {
        playerManager.PlayerResume();
    }

    public void AddMoneyToPlayer(int q)
    {
        //update ui
        //add money
        playerManager.AddMoney(q);
        uiManager.UpdateHUD(playerManager.GetMoney());
    }
    

    
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

    // Start is called before the first frame update
    void Start()
    {
       /// playerManager.player = GameObject.Find("Player");

        if (SceneManager.GetActiveScene().name != "MainMenu" && playerManager == null)
        {
            playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        }
        canMovePlayer = true;
    }

}
