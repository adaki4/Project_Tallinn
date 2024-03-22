using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region references
    public GameObject player;
    public PlayerInput PlayerInput {get; set;}
    public PlayerMovement PlayerMovement {get; set;}

    public static PlayerManager instance;

    bool _active;
    #endregion

    #region methods
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
             DontDestroyOnLoad(gameObject); //idk why outside the else it gets duplicated even w the return
        }
    }
    void Start()
    {
        player = GameObject.Find("Player");
        PlayerMovement = player.GetComponent<PlayerMovement>();
        PlayerInput = player.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
