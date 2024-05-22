using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public PlayerInput PlayerInput {get; set;}
    public PlayerMovement PlayerMovement {get; set;}

    public static PlayerManager instance;

    bool _active;
    

    protected int playerMoney;
    

    public void PlayerPause()
    {

        PlayerInput.enabled = false;
        PlayerMovement.enabled = false;
    }
    public void PlayerResume()
    {
        PlayerInput.enabled = true;
        PlayerMovement.enabled = true;
    }

    public void AddMoney(int q)
    {
        Debug.Log("Player gained " + q + " coins!");
        playerMoney += q;
    }

    public void Substractoney(int q)
    {
        playerMoney -= q;
    }

    public bool CanAfford(int q)
    {
        return playerMoney >= q;
    }

    public int GetMoney() { return playerMoney; }
    
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
             DontDestroyOnLoad(gameObject); //idk why outside the else it gets duplicated even w the return
        }
    }
    void Start()
    {
        player = GameObject.Find("Player");
        PlayerMovement = player.GetComponent<PlayerMovement>();
        PlayerInput = player.GetComponent<PlayerInput>();

        playerMoney = 0;
    }

}
