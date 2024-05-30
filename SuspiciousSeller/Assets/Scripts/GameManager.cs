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
    
    public bool SpendMoneyPlayer(int q, bool penalty=false)
    {
        //substract money
        bool spent = playerManager.SubstractMoney(q, penalty);
        //update ui
        uiManager.UpdateHUD(playerManager.GetMoney());
        return spent;
    }

    public bool canAffordPlayer(int q)
    {
        return playerManager.CanAfford(q);
    }

    public IEnumerator DelayEnd()
    {
        yield return new WaitForSeconds(5);
        ShopManager.instance.ShowStoreBuilding(false);
        playerManager.gameObject.SetActive(false);
        uiManager.gameObject.SetActive(false);
        CameraManager.instance.GetComponent<CameraFollow>().enabled = false;
        CameraManager.instance.transform.position = new Vector3(0,0,-2);
        ScenesManager.instance.LoadScene("Ending");
    }
    public void EndGame()
    {
        uiManager.EndGame();
        playerManager.Freeze(true);
        StartCoroutine(DelayEnd());
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
        if (SceneManager.GetActiveScene().name != "MainMenu" && playerManager == null)
        {
            playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        }
        canMovePlayer = true;
    }

}
