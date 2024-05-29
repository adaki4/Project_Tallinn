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

    public List<NPC> npcList = new();
    

    public void PausePlay()
    {
        Debug.Log("Game paused");
        Time.timeScale = 0;
    }
    public void ResumePlay()
    {
        Debug.Log("GameResumed");
        Time.timeScale = 1;

    }

    public void FreezePlayer(bool c)
    {
        playerManager.Freeze(c);
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

    public void EndGame()
    {
        //show text with winning condition, show shop with all the upgrades
        //maybe ending dialogue
        Debug.Log("You won :p ");
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
