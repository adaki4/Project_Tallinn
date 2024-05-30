using System;
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
    public bool hasVisitedMerchant;

    bool _active;
    

    protected int playerMoney;

    public void AddMoney(int q)
    {
        Debug.Log("Player gained " + q + " coins!");
        playerMoney += q;
    }

    public bool SubstractMoney(int q, bool penalty=false) //bool penalty for actions where player loses money regardless
    {
        if (q > playerMoney)
        {
            if (penalty)  { 
                playerMoney = 0;
            }
            Debug.Log(q);
            return true;
        }
        playerMoney -= q;
        return true;
    }
    public bool CanAfford(int q)
    {
        return playerMoney >= q;
    }

    public void Freeze(bool c)
    {
        PlayerInput.enabled = !c;
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
