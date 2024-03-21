using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region references
    public GameObject player;
    public PlayerInput PlayerInput {get; set;}
    public PlayerMovement PlayerMovement {get; set;}
    #endregion

    #region methods
    #endregion
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
