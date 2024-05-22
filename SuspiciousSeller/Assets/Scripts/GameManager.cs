using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerManager playerManager;
    public UIManager uiManager;
    public bool canMovePlayer = false;
    

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
        //add money
        playerManager.AddMoney(q);
        //update ui
        uiManager.UpdateHUD(playerManager.GetMoney());
    }
    
    public bool SpendMoneyPlayer(int q)
    {
        //substract money
        bool spent = playerManager.SubstractMoney(q);
        //update ui
        uiManager.UpdateHUD(playerManager.GetMoney());
        return spent;
    }

    public bool canAffordPlayer(int q)
    {
        return playerManager.CanAfford(q);
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
